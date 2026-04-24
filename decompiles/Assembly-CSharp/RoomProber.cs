// Decompiled with JetBrains decompiler
// Type: RoomProber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class RoomProber : ISim1000ms
{
  public List<Room> rooms = new List<Room>();
  private readonly KCompactedVector<CavityInfo> cavityInfos = new KCompactedVector<CavityInfo>(1024 /*0x0400*/);
  private readonly HandleVector<int>.Handle[] CellCavityID;
  private readonly RoomProber.RefreshModule refresh;
  private readonly HashSet<int> solidChanges = new HashSet<int>();
  private bool dirty = true;

  public RoomProber()
  {
    CavityInfo newCavity = this.CreateNewCavity();
    newCavity.cells = new List<int>()
    {
      Capacity = Grid.CellCount
    };
    for (int index = 0; index < Grid.CellCount; ++index)
      newCavity.cells.Add(index);
    this.CellCavityID = new HandleVector<int>.Handle[Grid.CellCount];
    Array.Fill<HandleVector<int>.Handle>(this.CellCavityID, newCavity.handle);
    this.solidChanges.Add(0);
    this.refresh = new RoomProber.RefreshModule(this);
    this.refresh.Initialize();
    this.Refresh();
    Game.Instance.OnSpawnComplete += new System.Action(this.Refresh);
    World.Instance.OnSolidChanged += new Action<int>(this.SolidChangedEvent);
    GameScenePartitioner.Instance.AddGlobalLayerListener(GameScenePartitioner.Instance.objectLayers[1], new Action<int, object>(this.OnBuildingsChanged));
    GameScenePartitioner.Instance.AddGlobalLayerListener(GameScenePartitioner.Instance.objectLayers[2], new Action<int, object>(this.OnBuildingsChanged));
  }

  private void SolidChangedEvent(int cell) => this.SolidChangedEvent(cell, true);

  private void OnBuildingsChanged(int cell, object building)
  {
    if (this.GetCavityForCell(cell) == null)
      return;
    this.solidChanges.Add(cell);
    this.dirty = true;
  }

  public void TriggerBuildingChangedEvent(int cell, object building)
  {
    this.OnBuildingsChanged(cell, building);
  }

  public void SolidChangedEvent(int cell, bool ignoreDoors)
  {
    if (ignoreDoors && Grid.HasDoor[cell])
      return;
    this.solidChanges.Add(cell);
    this.dirty = true;
  }

  private CavityInfo CreateNewCavity()
  {
    CavityInfo initial_data = new CavityInfo();
    initial_data.handle = this.cavityInfos.Allocate(initial_data);
    return initial_data;
  }

  private static bool IsCavityBoundary(int cell)
  {
    return (Grid.BuildMasks[cell] & (Grid.BuildFlags.Solid | Grid.BuildFlags.Foundation)) != 0 || Grid.HasDoor[cell];
  }

  public void Refresh() => this.refresh.Run();

  public void Sim1000ms(float dt)
  {
    if (!this.dirty)
      return;
    this.Refresh();
  }

  private void CreateRoom(CavityInfo cavity)
  {
    Debug.Assert(cavity.room == null);
    Room room = new Room() { cavity = cavity };
    cavity.room = room;
    this.rooms.Add(room);
    room.roomType = Db.Get().RoomTypes.GetRoomType(room);
    this.AssignBuildingsToRoom(room);
  }

  private void ClearRoom(Room room)
  {
    this.UnassignBuildingsToRoom(room);
    room.CleanUp();
    this.rooms.Remove(room);
  }

  private void RefreshRooms(List<KPrefabID> dirtyEntities)
  {
    int maxRoomSize = TuningData<RoomProber.Tuning>.Get().maxRoomSize;
    foreach (CavityInfo data in this.cavityInfos.GetDataList())
    {
      if (data.dirty)
      {
        Debug.Assert(data.room == null, (object) "I expected info.room to always be null by this point");
        if (data.NumCells > 0)
        {
          if (data.NumCells <= maxRoomSize)
            this.CreateRoom(data);
          foreach (KMonoBehaviour building in data.buildings)
            building.Trigger(144050788, (object) data.room);
          foreach (KMonoBehaviour plant in data.plants)
            plant.Trigger(144050788, (object) data.room);
        }
        data.dirty = false;
      }
    }
    foreach (KPrefabID dirtyEntity in dirtyEntities)
    {
      if ((UnityEngine.Object) dirtyEntity != (UnityEngine.Object) null)
        dirtyEntity.Trigger(144050788, (object) null);
    }
    this.dirty = false;
  }

  private void AssignBuildingsToRoom(Room room)
  {
    Debug.Assert(room != null);
    RoomType roomType = room.roomType;
    if (roomType == Db.Get().RoomTypes.Neutral)
      return;
    foreach (KPrefabID building in room.buildings)
    {
      Assignable component;
      if (!((UnityEngine.Object) building == (UnityEngine.Object) null) && !building.HasTag(GameTags.NotRoomAssignable) && building.TryGetComponent<Assignable>(out component) && (roomType.primary_constraint == null || !roomType.primary_constraint.building_criteria(building)))
        component.Assign((IAssignableIdentity) room);
    }
  }

  private void UnassignKPrefabIDs(Room room, List<KPrefabID> buildings)
  {
    foreach (KPrefabID building in buildings)
    {
      if (!((UnityEngine.Object) building == (UnityEngine.Object) null))
      {
        building.Trigger(144050788, (object) null);
        Assignable component;
        if (building.TryGetComponent<Assignable>(out component) && component.assignee == room)
          component.Unassign();
      }
    }
  }

  private void UnassignBuildingsToRoom(Room room)
  {
    Debug.Assert(room != null);
    this.UnassignKPrefabIDs(room, room.buildings);
    this.UnassignKPrefabIDs(room, room.plants);
  }

  public void UpdateRoom(CavityInfo cavity)
  {
    if (cavity == null)
      return;
    if (cavity.room != null)
    {
      this.ClearRoom(cavity.room);
      cavity.room = (Room) null;
    }
    this.CreateRoom(cavity);
    foreach (KPrefabID building in cavity.buildings)
    {
      if ((UnityEngine.Object) building != (UnityEngine.Object) null)
        building.Trigger(144050788, (object) cavity.room);
    }
    foreach (KPrefabID plant in cavity.plants)
    {
      if ((UnityEngine.Object) plant != (UnityEngine.Object) null)
        plant.Trigger(144050788, (object) cavity.room);
    }
  }

  public Room GetRoomOfGameObject(GameObject go)
  {
    if ((UnityEngine.Object) go == (UnityEngine.Object) null)
      return (Room) null;
    int cell = Grid.PosToCell(go);
    if (!Grid.IsValidCell(cell))
      return (Room) null;
    return this.GetCavityForCell(cell)?.room;
  }

  public bool IsInRoomType(GameObject go, RoomType checkType)
  {
    Room roomOfGameObject = this.GetRoomOfGameObject(go);
    if (roomOfGameObject == null)
      return false;
    RoomType roomType = roomOfGameObject.roomType;
    return checkType == roomType;
  }

  private CavityInfo GetCavityInfo(HandleVector<int>.Handle id)
  {
    CavityInfo cavityInfo = (CavityInfo) null;
    if (id.IsValid())
      cavityInfo = this.cavityInfos.GetData(id);
    return cavityInfo;
  }

  public CavityInfo GetCavityForCell(int cell)
  {
    return !Grid.IsValidCell(cell) ? (CavityInfo) null : this.GetCavityInfo(this.CellCavityID[cell]);
  }

  public class Tuning : TuningData<RoomProber.Tuning>
  {
    public int maxRoomSize;
  }

  private struct RefreshModule(RoomProber roomProber)
  {
    private readonly RoomProber.RefreshModule.CavityBuilder cavityBuilder = new RoomProber.RefreshModule.CavityBuilder();
    private readonly RoomProber roomProber = roomProber;
    private readonly List<int> dirtyCells = new List<int>();
    private readonly List<HandleVector<int>.Handle> condemnedCavities = new List<HandleVector<int>.Handle>();
    private readonly List<CavityInfo> newCavities = new List<CavityInfo>();
    private readonly List<KPrefabID> dirtyEntities = new List<KPrefabID>();
    private readonly HashSet<int> visitedCells = new HashSet<int>();
    private readonly HashSet<HandleVector<int>.Handle> visitedCavities = new HashSet<HandleVector<int>.Handle>();
    private readonly HashSet<RoomProber.RefreshModule.BuildingId> visitedBuildings = new HashSet<RoomProber.RefreshModule.BuildingId>();
    private Func<int, bool> addCellToGrid = (Func<int, bool>) null;

    public void Initialize() => this.addCellToGrid = new Func<int, bool>(this.AddCellToGrid);

    public void Run()
    {
      this.CollectDirtyCells();
      this.CollectCondemnedCavities();
      this.BuildNewCavities();
      foreach (HandleVector<int>.Handle condemnedCavity in this.condemnedCavities)
      {
        CavityInfo data = this.roomProber.cavityInfos.GetData(condemnedCavity);
        this.dirtyEntities.Capacity = Math.Max(this.dirtyEntities.Capacity, this.dirtyEntities.Count + data.creatures.Count + data.otherEntities.Count);
        foreach (KPrefabID creature in data.creatures)
          this.dirtyEntities.Add(creature);
        foreach (KPrefabID otherEntity in data.otherEntities)
          this.dirtyEntities.Add(otherEntity);
        if (data.room != null)
          this.roomProber.ClearRoom(data.room);
        this.roomProber.cavityInfos.Free(condemnedCavity);
      }
      this.AddRoomContentsToCavities();
      this.roomProber.RefreshRooms(this.dirtyEntities);
      this.Recycle();
    }

    private readonly void Recycle()
    {
      this.dirtyCells.Clear();
      this.condemnedCavities.Clear();
      this.newCavities.Clear();
      this.dirtyEntities.Clear();
    }

    private readonly bool AddCellToGrid(int flood_cell)
    {
      if (RoomProber.IsCavityBoundary(flood_cell))
      {
        this.roomProber.CellCavityID[flood_cell] = HandleVector<int>.InvalidHandle;
        return false;
      }
      this.cavityBuilder.AddCell(flood_cell);
      this.roomProber.CellCavityID[flood_cell] = this.cavityBuilder.CavityID;
      return true;
    }

    private readonly unsafe void CollectDirtyCells()
    {
      int* numPtr = stackalloc int[5]
      {
        0,
        -Grid.WidthInCells,
        -1,
        1,
        Grid.WidthInCells
      };
      foreach (int solidChange in this.roomProber.solidChanges)
      {
        for (int index = 0; index < 5; ++index)
        {
          int cell = solidChange + numPtr[index];
          if (Grid.IsValidCell(cell) && this.visitedCells.Add(cell))
            this.dirtyCells.Add(cell);
        }
      }
      this.visitedCells.Clear();
      this.roomProber.solidChanges.Clear();
    }

    private readonly void CollectCondemnedCavities()
    {
      foreach (int dirtyCell in this.dirtyCells)
      {
        if (!this.visitedCells.Contains(dirtyCell))
        {
          HandleVector<int>.Handle handle = this.roomProber.CellCavityID[dirtyCell];
          if (!handle.IsValid())
          {
            this.visitedCells.Add(dirtyCell);
          }
          else
          {
            if (this.visitedCavities.Add(handle))
              this.condemnedCavities.Add(handle);
            CavityInfo data = this.roomProber.cavityInfos.GetData(handle);
            this.visitedCells.EnsureCapacity(this.visitedCells.Count + data.cells.Count);
            foreach (int cell in data.cells)
            {
              this.roomProber.CellCavityID[cell] = HandleVector<int>.InvalidHandle;
              this.visitedCells.Add(cell);
            }
          }
        }
      }
      this.visitedCells.Clear();
      this.visitedCavities.Clear();
    }

    private readonly void BuildNewCavities()
    {
      int num = 0;
      foreach (HandleVector<int>.Handle condemnedCavity in this.condemnedCavities)
        num += this.roomProber.cavityInfos.GetData(condemnedCavity).NumCells;
      this.dirtyCells.Capacity = Math.Max(this.dirtyCells.Capacity, this.dirtyCells.Count + num);
      foreach (HandleVector<int>.Handle condemnedCavity in this.condemnedCavities)
      {
        foreach (int cell in this.roomProber.cavityInfos.GetData(condemnedCavity).cells)
          this.dirtyCells.Add(cell);
      }
      int index = this.condemnedCavities.Count > 0 ? 0 : -1;
      foreach (int dirtyCell in this.dirtyCells)
      {
        if (!this.visitedCells.Contains(dirtyCell) && !this.roomProber.CellCavityID[dirtyCell].IsValid())
        {
          if (RoomProber.IsCavityBoundary(dirtyCell))
          {
            this.visitedCells.Add(dirtyCell);
            this.roomProber.CellCavityID[dirtyCell] = HandleVector<int>.InvalidHandle;
          }
          else
          {
            CavityInfo newCavity = this.roomProber.CreateNewCavity();
            if (index >= 0)
            {
              CavityInfo data = this.roomProber.cavityInfos.GetData(this.condemnedCavities[index]);
              newCavity.cells = data.cells;
              newCavity.cells.Clear();
              data.cells = (List<int>) null;
              ++index;
              if (index >= this.condemnedCavities.Count)
                index = -1;
            }
            else
              newCavity.cells = new List<int>();
            this.cavityBuilder.Reset(newCavity.handle);
            GameUtil.FloodFillConditional(dirtyCell, this.addCellToGrid, this.visitedCells, newCavity.cells);
            DebugUtil.DevAssert(this.cavityBuilder.NumCells > 0, "Degenerate cavities should have been detected and rejected prior to this point");
            newCavity.minX = this.cavityBuilder.MinX;
            newCavity.minY = this.cavityBuilder.MinY;
            newCavity.maxX = this.cavityBuilder.MaxX;
            newCavity.maxY = this.cavityBuilder.MaxY;
            this.newCavities.Add(newCavity);
          }
        }
      }
      this.visitedCells.Clear();
    }

    private void AddRoomContentsToCavities()
    {
      int maxRoomSize = TuningData<RoomProber.Tuning>.Get().maxRoomSize;
      foreach (CavityInfo newCavity in this.newCavities)
      {
        if (newCavity.NumCells <= maxRoomSize)
        {
          foreach (int cell in newCavity.cells)
          {
            GameObject gameObject = Grid.Objects[cell, 1];
            if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
            {
              KPrefabID component = gameObject.GetComponent<KPrefabID>();
              if (this.visitedBuildings.Add(new RoomProber.RefreshModule.BuildingId()
              {
                prefab = component.GetHashCode(),
                instance = component.InstanceID
              }))
              {
                if (component.HasTag(GameTags.RoomProberBuilding))
                  newCavity.AddBuilding(component);
                else if (component.HasTag(GameTags.Plant))
                  newCavity.AddPlants(component);
              }
            }
          }
        }
      }
      this.visitedBuildings.Clear();
    }

    private class CavityBuilder
    {
      public HandleVector<int>.Handle CavityID { get; private set; }

      public int MinX { get; private set; }

      public int MinY { get; private set; }

      public int MaxX { get; private set; }

      public int MaxY { get; private set; }

      public int NumCells { get; private set; }

      public void Reset(HandleVector<int>.Handle search_id)
      {
        this.CavityID = search_id;
        this.NumCells = 0;
        this.MinX = int.MaxValue;
        this.MinY = int.MaxValue;
        this.MaxX = 0;
        this.MaxY = 0;
      }

      public void AddCell(int flood_cell)
      {
        int x;
        int y;
        Grid.CellToXY(flood_cell, out x, out y);
        this.MinX = Math.Min(x, this.MinX);
        this.MinY = Math.Min(y, this.MinY);
        this.MaxX = Math.Max(x, this.MaxX);
        this.MaxY = Math.Max(y, this.MaxY);
        ++this.NumCells;
      }
    }

    private struct BuildingId
    {
      public int prefab;
      public int instance;
    }
  }
}

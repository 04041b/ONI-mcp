// Decompiled with JetBrains decompiler
// Type: FishOvercrowingManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/FishOvercrowingManager")]
public class FishOvercrowingManager : KMonoBehaviour, ISim1000ms
{
  public static FishOvercrowingManager Instance;
  private readonly List<KPrefabID> allAquaticEntities = new List<KPrefabID>();
  private readonly List<FishOvercrowingManager.Pond> ponds = new List<FishOvercrowingManager.Pond>();
  private FishOvercrowingManager.Cell[] cells;
  private int versionCounter = 2;

  public static void DestroyInstance()
  {
    FishOvercrowingManager.Instance = (FishOvercrowingManager) null;
  }

  protected override void OnPrefabInit()
  {
    FishOvercrowingManager.Instance = this;
    this.cells = new FishOvercrowingManager.Cell[Grid.CellCount];
  }

  public void Add(KPrefabID aquaticEntity) => this.allAquaticEntities.Add(aquaticEntity);

  public void Remove(KPrefabID aquaticEntity)
  {
    if (aquaticEntity.IsNullOrDestroyed())
      return;
    for (int index = this.allAquaticEntities.Count - 1; index >= 0; --index)
    {
      KPrefabID allAquaticEntity = this.allAquaticEntities[index];
      if (!allAquaticEntity.IsNullOrDestroyed() && allAquaticEntity.InstanceID == aquaticEntity.InstanceID)
      {
        this.allAquaticEntities.RemoveAt(index);
        break;
      }
    }
  }

  public void Sim1000ms(float dt)
  {
    int version = this.versionCounter++;
    for (int index = 0; index != this.ponds.Count; ++index)
    {
      FishOvercrowingManager.Pond pond = this.ponds[index];
      pond.fishes.Clear();
      pond.eggs.Clear();
      pond.cellCount = 0;
      pond.occupancy.dirty = true;
    }
    int index1 = this.ponds.Count == 0 ? -1 : 0;
    QueuePool<int, FishOvercrowingManager>.PooledQueue pooledQueue = QueuePool<int, FishOvercrowingManager>.Allocate();
    foreach (KPrefabID allAquaticEntity in this.allAquaticEntities)
    {
      if (!allAquaticEntity.IsNullOrDestroyed())
      {
        int cell1 = Grid.PosToCell((KMonoBehaviour) allAquaticEntity);
        if (Grid.IsValidCell(cell1))
        {
          pooledQueue.Clear();
          pooledQueue.Enqueue(cell1);
          FishOvercrowingManager.Cell cell2 = this.cells[cell1];
          int num;
          if (cell2.Version == version)
            num = cell2.PondIndex;
          else if (index1 != -1 && index1 < this.ponds.Count)
          {
            num = index1;
            ++index1;
            if (index1 == this.ponds.Count)
              index1 = -1;
          }
          else
          {
            this.ponds.Add(new FishOvercrowingManager.Pond()
            {
              fishes = new List<KPrefabID>(),
              eggs = new List<KPrefabID>()
            });
            num = this.ponds.Count - 1;
          }
          FishOvercrowingManager.Pond pond = this.ponds[num];
          if (allAquaticEntity.HasTag(GameTags.Egg))
            pond.eggs.Add(allAquaticEntity);
          else
            pond.fishes.Add(allAquaticEntity);
          while (true)
          {
            int cell3;
            do
            {
              if (!pooledQueue.TryDequeue(ref cell3))
                goto label_19;
            }
            while (!Grid.IsValidCell(cell3) || this.cells[cell3].Version == version || !Grid.IsNavigatableLiquid(cell3));
            this.cells[cell3] = new FishOvercrowingManager.Cell(version, num);
            ++pond.cellCount;
            pooledQueue.Enqueue(Grid.CellLeft(cell3));
            pooledQueue.Enqueue(Grid.CellRight(cell3));
            pooledQueue.Enqueue(Grid.CellAbove(cell3));
            pooledQueue.Enqueue(Grid.CellBelow(cell3));
          }
        }
        else
          continue;
      }
      else
        continue;
label_19:;
    }
    pooledQueue.Recycle();
    if (index1 != -1)
    {
      int count = this.ponds.Count - index1;
      if (count > 0)
        this.ponds.RemoveRange(index1, count);
    }
    this.allAquaticEntities.RemoveAll(new Predicate<KPrefabID>(Util.IsNullOrDestroyed));
  }

  public FishOvercrowingManager.Pond GetPond(int cell)
  {
    if (!Grid.IsValidCell(cell))
      return (FishOvercrowingManager.Pond) null;
    FishOvercrowingManager.Cell cell1 = this.cells[cell];
    return cell1.Version != this.versionCounter - 1 ? (FishOvercrowingManager.Pond) null : this.ponds[cell1.PondIndex];
  }

  public int GetFishInPondCount(int cell, HashSet<Tag> accepted_tags)
  {
    int fishInPondCount = 0;
    FishOvercrowingManager.Pond pond = this.GetPond(cell);
    if (pond == null)
      return 0;
    foreach (KPrefabID fish in pond.fishes)
    {
      if (!fish.HasTag(GameTags.Creatures.Bagged) && !fish.HasTag(GameTags.Trapped) && accepted_tags.Contains(fish.PrefabTag))
        ++fishInPondCount;
    }
    return fishInPondCount;
  }

  private readonly struct Cell(int version, int pondIndex)
  {
    private readonly int version = version;
    private readonly int pondIndex = pondIndex;

    public int Version => this.version;

    public int PondIndex => this.pondIndex;
  }

  public class Pond
  {
    public List<KPrefabID> fishes;
    public List<KPrefabID> eggs;
    public int cellCount;
    public OvercrowdingMonitor.Occupancy occupancy = new OvercrowdingMonitor.Occupancy();

    public int FishCount => this.fishes.Count;

    public int EggCount => this.eggs.Count;
  }
}

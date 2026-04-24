// Decompiled with JetBrains decompiler
// Type: ClustercraftInteriorDoor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ClustercraftInteriorDoor : KMonoBehaviour
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Components.ClusterCraftInteriorDoors.Add(this);
  }

  protected override void OnCleanUp()
  {
    Components.ClusterCraftInteriorDoors.Remove(this);
    foreach (int occupiedGridCell in this.GetComponent<OccupyArea>().GetOccupiedGridCells())
      Grid.HasDoor[occupiedGridCell] = false;
    base.OnCleanUp();
  }
}

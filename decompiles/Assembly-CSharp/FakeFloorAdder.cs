// Decompiled with JetBrains decompiler
// Type: FakeFloorAdder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FakeFloorAdder : KMonoBehaviour
{
  public CellOffset[] floorOffsets;
  public bool initiallyActive = true;
  private bool isActive;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (!this.initiallyActive)
      return;
    this.SetFloor(true);
  }

  public void SetFloor(bool active)
  {
    if (this.isActive == active)
      return;
    int cell = Grid.PosToCell((KMonoBehaviour) this);
    Rotatable component = this.GetComponent<Rotatable>();
    foreach (CellOffset floorOffset in this.floorOffsets)
    {
      CellOffset offset = (Object) component == (Object) null ? floorOffset : component.GetRotatedCellOffset(floorOffset);
      int num = Grid.OffsetCell(cell, offset);
      if (active)
        Grid.FakeFloor.Add(num);
      else
        Grid.FakeFloor.Remove(num);
      Pathfinding.Instance.AddDirtyNavGridCell(num);
    }
    this.isActive = active;
  }

  protected override void OnCleanUp()
  {
    this.SetFloor(false);
    base.OnCleanUp();
  }
}

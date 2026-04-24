// Decompiled with JetBrains decompiler
// Type: CellQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellQuery : PathFinderQuery
{
  private int targetCell;

  public CellQuery Reset(int target_cell)
  {
    this.targetCell = target_cell;
    return this;
  }

  public override bool IsMatch(int cell, int parent_cell, int cost) => cell == this.targetCell;
}

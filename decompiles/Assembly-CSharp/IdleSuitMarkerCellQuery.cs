// Decompiled with JetBrains decompiler
// Type: IdleSuitMarkerCellQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class IdleSuitMarkerCellQuery : PathFinderQuery
{
  private int targetCell;
  private bool isRotated;
  private int markerX;

  public IdleSuitMarkerCellQuery(bool is_rotated, int marker_x)
  {
    this.targetCell = Grid.InvalidCell;
    this.isRotated = is_rotated;
    this.markerX = marker_x;
  }

  public override bool IsMatch(int cell, int parent_cell, int cost)
  {
    if (!Grid.PreventIdleTraversal[cell] && Grid.CellToXY(cell).x < this.markerX != this.isRotated)
      this.targetCell = cell;
    return this.targetCell != Grid.InvalidCell;
  }

  public override int GetResultCell() => this.targetCell;
}

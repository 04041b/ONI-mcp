// Decompiled with JetBrains decompiler
// Type: CellVisibility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellVisibility
{
  private int MinX;
  private int MinY;
  private int MaxX;
  private int MaxY;

  public CellVisibility()
  {
    Grid.GetVisibleExtents(out this.MinX, out this.MinY, out this.MaxX, out this.MaxY);
  }

  public bool IsVisible(int cell)
  {
    int num1 = Grid.CellColumn(cell);
    if (num1 < this.MinX || num1 > this.MaxX)
      return false;
    int num2 = Grid.CellRow(cell);
    return num2 >= this.MinY && num2 <= this.MaxY;
  }
}

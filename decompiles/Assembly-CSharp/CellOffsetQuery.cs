// Decompiled with JetBrains decompiler
// Type: CellOffsetQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellOffsetQuery : CellArrayQuery
{
  public CellArrayQuery Reset(int cell, CellOffset[] offsets)
  {
    int[] target_cells = new int[offsets.Length];
    for (int index = 0; index < offsets.Length; ++index)
      target_cells[index] = Grid.OffsetCell(cell, offsets[index]);
    this.Reset(target_cells);
    return (CellArrayQuery) this;
  }
}

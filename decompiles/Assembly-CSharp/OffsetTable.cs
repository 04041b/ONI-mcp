// Decompiled with JetBrains decompiler
// Type: OffsetTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public static class OffsetTable
{
  public static CellOffset[][] Mirror(CellOffset[][] table)
  {
    List<CellOffset[]> cellOffsetArrayList = new List<CellOffset[]>();
    foreach (CellOffset[] cellOffsetArray1 in table)
    {
      cellOffsetArrayList.Add(cellOffsetArray1);
      if (cellOffsetArray1[0].x != 0)
      {
        CellOffset[] cellOffsetArray2 = new CellOffset[cellOffsetArray1.Length];
        for (int index = 0; index < cellOffsetArray2.Length; ++index)
        {
          cellOffsetArray2[index] = cellOffsetArray1[index];
          cellOffsetArray2[index].x = -cellOffsetArray2[index].x;
        }
        cellOffsetArrayList.Add(cellOffsetArray2);
      }
    }
    return cellOffsetArrayList.ToArray();
  }
}

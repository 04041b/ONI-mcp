// Decompiled with JetBrains decompiler
// Type: DebugCellDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/DebugCellDrawer")]
public class DebugCellDrawer : KMonoBehaviour
{
  public List<int> cells;

  private void Update()
  {
    for (int index = 0; index < this.cells.Count; ++index)
    {
      if (this.cells[index] != PathFinder.InvalidCell)
        DebugExtension.DebugPoint(Grid.CellToPosCCF(this.cells[index], Grid.SceneLayer.Background));
    }
  }
}

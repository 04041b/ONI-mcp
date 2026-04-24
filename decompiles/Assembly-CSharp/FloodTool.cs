// Decompiled with JetBrains decompiler
// Type: FloodTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class FloodTool : InterfaceTool
{
  public Func<int, bool> floodCriteria;
  public Action<List<int>> paintArea;
  protected Color32 areaColour = (Color32) new Color(0.5f, 0.7f, 0.5f, 0.2f);
  protected int mouseCell = -1;

  public List<int> Flood(int startCell)
  {
    HashSetPool<int, FloodTool>.PooledHashSet visited_cells = HashSetPool<int, FloodTool>.Allocate();
    List<int> valid_cells = new List<int>();
    GameUtil.FloodFillConditional(startCell, this.floodCriteria, (HashSet<int>) visited_cells, valid_cells);
    visited_cells.Recycle();
    return valid_cells;
  }

  public override void OnLeftClickDown(Vector3 cursor_pos)
  {
    base.OnLeftClickDown(cursor_pos);
    this.paintArea(this.Flood(Grid.PosToCell(cursor_pos)));
  }

  public override void OnMouseMove(Vector3 cursor_pos)
  {
    base.OnMouseMove(cursor_pos);
    this.mouseCell = Grid.PosToCell(cursor_pos);
  }
}

// Decompiled with JetBrains decompiler
// Type: LogicPortVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LogicPortVisualizer : ILogicUIElement, IUniformGridObject
{
  private int cell;
  private LogicPortSpriteType spriteType;

  public LogicPortVisualizer(int cell, LogicPortSpriteType sprite_type)
  {
    this.cell = cell;
    this.spriteType = sprite_type;
  }

  public int GetLogicUICell() => this.cell;

  public Vector2 PosMin() => (Vector2) Grid.CellToPos2D(this.cell);

  public Vector2 PosMax() => (Vector2) Grid.CellToPos2D(this.cell);

  public LogicPortSpriteType GetLogicPortSpriteType() => this.spriteType;
}

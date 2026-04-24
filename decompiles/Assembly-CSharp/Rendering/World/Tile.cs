// Decompiled with JetBrains decompiler
// Type: Rendering.World.Tile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Rendering.World;

public struct Tile(int idx, int tile_x, int tile_y, int mask_count)
{
  public int Idx = idx;
  public TileCells TileCells = new TileCells(tile_x, tile_y);
  public int MaskCount = mask_count;
}

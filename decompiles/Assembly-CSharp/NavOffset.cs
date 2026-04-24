// Decompiled with JetBrains decompiler
// Type: NavOffset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct NavOffset
{
  public NavType navType;
  public CellOffset offset;

  public NavOffset(NavType nav_type, int x, int y)
  {
    this.navType = nav_type;
    this.offset.x = x;
    this.offset.y = y;
  }
}

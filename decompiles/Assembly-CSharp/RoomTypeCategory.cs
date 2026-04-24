// Decompiled with JetBrains decompiler
// Type: RoomTypeCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RoomTypeCategory : Resource
{
  public string colorName { get; private set; }

  public string icon { get; private set; }

  public RoomTypeCategory(string id, string name, string colorName, string icon)
    : base(id, name)
  {
    this.colorName = colorName;
    this.icon = icon;
  }
}

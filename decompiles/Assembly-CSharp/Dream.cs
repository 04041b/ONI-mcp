// Decompiled with JetBrains decompiler
// Type: Dream
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Dream : Resource
{
  public string BackgroundAnim;
  public Sprite[] Icons;
  public float secondPerImage = 2.4f;

  public Dream(string id, ResourceSet parent, string background, string[] icons_sprite_names)
    : base(id, parent)
  {
    this.Icons = new Sprite[icons_sprite_names.Length];
    this.BackgroundAnim = background;
    for (int index = 0; index < icons_sprite_names.Length; ++index)
      this.Icons[index] = Assets.GetSprite((HashedString) icons_sprite_names[index]);
  }

  public Dream(
    string id,
    ResourceSet parent,
    string background,
    string[] icons_sprite_names,
    float durationPerImage)
    : this(id, parent, background, icons_sprite_names)
  {
    this.secondPerImage = durationPerImage;
  }
}

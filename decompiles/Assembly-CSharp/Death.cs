// Decompiled with JetBrains decompiler
// Type: Death
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Death : Resource
{
  public string preAnim;
  public string loopAnim;
  public string sound;
  public string description;

  public Death(
    string id,
    ResourceSet parent,
    string name,
    string description,
    string pre_anim,
    string loop_anim)
    : base(id, parent, name)
  {
    this.preAnim = pre_anim;
    this.loopAnim = loop_anim;
    this.description = description;
  }
}

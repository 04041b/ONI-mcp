// Decompiled with JetBrains decompiler
// Type: Face
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Face : Resource
{
  public HashedString hash;
  public HashedString headFXHash;
  private const string SYMBOL_PREFIX = "headfx_";

  public Face(string id, string headFXSymbol = null)
    : base(id)
  {
    this.hash = new HashedString(id);
    this.headFXHash = (HashedString) headFXSymbol;
  }
}

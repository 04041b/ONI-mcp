// Decompiled with JetBrains decompiler
// Type: HatListable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class HatListable : IListableOption
{
  public HatListable(string name, string hat)
  {
    this.name = name;
    this.hat = hat;
  }

  public string name { get; private set; }

  public string hat { get; private set; }

  public string GetProperName() => this.name;
}

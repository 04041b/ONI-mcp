// Decompiled with JetBrains decompiler
// Type: Blueprints
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Blueprints
{
  public BlueprintCollection all = new BlueprintCollection();
  public BlueprintCollection skinsRelease = new BlueprintCollection();
  public BlueprintProvider[] skinsReleaseProviders = new BlueprintProvider[7]
  {
    (BlueprintProvider) new Blueprints_U51AndBefore(),
    (BlueprintProvider) new Blueprints_DlcPack2(),
    (BlueprintProvider) new Blueprints_U53(),
    (BlueprintProvider) new Blueprints_DlcPack3(),
    (BlueprintProvider) new Blueprints_DlcPack4(),
    (BlueprintProvider) new Blueprints_U57(),
    (BlueprintProvider) new Blueprints_CosmeticPack1()
  };
  private static Blueprints instance;

  public static Blueprints Get()
  {
    if (Blueprints.instance == null)
    {
      Blueprints.instance = new Blueprints();
      Blueprints.instance.all.AddBlueprintsFrom<Blueprints_Default>(new Blueprints_Default());
      foreach (BlueprintProvider skinsReleaseProvider in Blueprints.instance.skinsReleaseProviders)
        Blueprints.instance.skinsRelease.AddBlueprintsFrom<BlueprintProvider>(skinsReleaseProvider);
      Blueprints.instance.all.AddBlueprintsFrom(Blueprints.instance.skinsRelease);
      Blueprints.instance.skinsRelease.PostProcess();
      Blueprints.instance.all.PostProcess();
    }
    return Blueprints.instance;
  }
}

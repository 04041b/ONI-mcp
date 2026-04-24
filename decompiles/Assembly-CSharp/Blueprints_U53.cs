// Decompiled with JetBrains decompiler
// Type: Blueprints_U53
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class Blueprints_U53 : BlueprintProvider
{
  public override void SetupBlueprints()
  {
    this.AddBuilding("LuxuryBed", PermitRarity.Loyalty, "permit_elegantbed_hatch", "elegantbed_hatch_kanim");
    this.AddBuilding("LuxuryBed", PermitRarity.Loyalty, "permit_elegantbed_pipsqueak", "elegantbed_pipsqueak_kanim");
  }
}

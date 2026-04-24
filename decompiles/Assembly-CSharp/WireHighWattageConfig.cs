// Decompiled with JetBrains decompiler
// Type: WireHighWattageConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class WireHighWattageConfig : BaseWireConfig
{
  public const string ID = "HighWattageWire";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR2 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR5 = TUNING.BUILDINGS.DECOR.PENALTY.TIER5;
    EffectorValues noise = none;
    BuildingDef buildingDef = this.CreateBuildingDef("HighWattageWire", "utilities_electric_insulated_kanim", 3f, tieR2, 0.05f, tieR5, noise);
    buildingDef.BuildLocationRule = BuildLocationRule.NotInTiles;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.POWER);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.WIRE);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    this.DoPostConfigureComplete(Wire.WattageRating.Max20000, go);
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
    base.DoPostConfigureUnderConstruction(go);
  }
}

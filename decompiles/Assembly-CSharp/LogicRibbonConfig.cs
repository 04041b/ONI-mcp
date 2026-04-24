// Decompiled with JetBrains decompiler
// Type: LogicRibbonConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class LogicRibbonConfig : BaseLogicWireConfig
{
  public const string ID = "LogicRibbon";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR0_1 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR0_2 = TUNING.BUILDINGS.DECOR.PENALTY.TIER0;
    EffectorValues noise = none;
    BuildingDef buildingDef = this.CreateBuildingDef("LogicRibbon", "logic_ribbon_kanim", 10f, tieR0_1, tieR0_2, noise);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.AUTOMATION);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    this.DoPostConfigureComplete(LogicWire.BitDepth.FourBit, go);
  }
}

// Decompiled with JetBrains decompiler
// Type: LogicWireConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class LogicWireConfig : BaseLogicWireConfig
{
  public const string ID = "LogicWire";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tierTiny = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER_TINY;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR0 = TUNING.BUILDINGS.DECOR.PENALTY.TIER0;
    EffectorValues noise = none;
    BuildingDef buildingDef = this.CreateBuildingDef("LogicWire", "logic_wires_kanim", 3f, tierTiny, tieR0, noise);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.AUTOMATION);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    this.DoPostConfigureComplete(LogicWire.BitDepth.OneBit, go);
  }
}

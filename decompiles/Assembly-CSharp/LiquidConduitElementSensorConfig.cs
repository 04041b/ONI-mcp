// Decompiled with JetBrains decompiler
// Type: LiquidConduitElementSensorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LiquidConduitElementSensorConfig : ConduitSensorConfig
{
  public static string ID = "LiquidConduitElementSensor";

  protected override ConduitType ConduitType => ConduitType.Liquid;

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = this.CreateBuildingDef(LiquidConduitElementSensorConfig.ID, "liquid_element_sensor_kanim", TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0, TUNING.MATERIALS.REFINED_METALS, new List<LogicPorts.Port>()
    {
      LogicPorts.Port.OutputPort(LogicSwitch.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITELEMENTSENSOR.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITELEMENTSENSOR.LOGIC_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITELEMENTSENSOR.LOGIC_PORT_INACTIVE, true)
    });
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, LiquidConduitElementSensorConfig.ID);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    base.DoPostConfigureComplete(go);
    go.AddOrGet<Filterable>().filterElementState = Filterable.ElementState.Liquid;
    ConduitElementSensor conduitElementSensor = go.AddOrGet<ConduitElementSensor>();
    conduitElementSensor.manuallyControlled = false;
    conduitElementSensor.conduitType = this.ConduitType;
    conduitElementSensor.defaultState = false;
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayInFrontOfConduits);
  }
}

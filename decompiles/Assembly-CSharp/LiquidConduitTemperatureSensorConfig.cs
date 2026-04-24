// Decompiled with JetBrains decompiler
// Type: LiquidConduitTemperatureSensorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LiquidConduitTemperatureSensorConfig : ConduitSensorConfig
{
  public static string ID = "LiquidConduitTemperatureSensor";

  protected override ConduitType ConduitType => ConduitType.Liquid;

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = this.CreateBuildingDef(LiquidConduitTemperatureSensorConfig.ID, "liquid_temperature_sensor_kanim", TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0, TUNING.MATERIALS.REFINED_METALS, new List<LogicPorts.Port>()
    {
      LogicPorts.Port.OutputPort(LogicSwitch.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITTEMPERATURESENSOR.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITTEMPERATURESENSOR.LOGIC_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITTEMPERATURESENSOR.LOGIC_PORT_INACTIVE, true)
    });
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, LiquidConduitTemperatureSensorConfig.ID);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    base.DoPostConfigureComplete(go);
    ConduitTemperatureSensor temperatureSensor = go.AddComponent<ConduitTemperatureSensor>();
    temperatureSensor.conduitType = this.ConduitType;
    temperatureSensor.Threshold = 280f;
    temperatureSensor.ActivateAboveThreshold = true;
    temperatureSensor.manuallyControlled = false;
    temperatureSensor.rangeMin = 0.0f;
    temperatureSensor.rangeMax = 9999f;
    temperatureSensor.defaultState = false;
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayInFrontOfConduits);
  }
}

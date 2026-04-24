// Decompiled with JetBrains decompiler
// Type: PropGravitasWallPurpleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class PropGravitasWallPurpleConfig : IBuildingConfig
{
  public const string ID = "PropGravitasWallPurple";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR0_1 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER0;
    string[] rawMinerals = MATERIALS.RAW_MINERALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR0_2 = DECOR.BONUS.TIER0;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("PropGravitasWallPurple", 1, 1, "walls_gravitas_purple_kanim", 30, 30f, tieR0_1, rawMinerals, 1600f, BuildLocationRule.NotInTiles, tieR0_2, noise);
    buildingDef.PermittedRotations = PermittedRotations.R360;
    buildingDef.Entombable = false;
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.DefaultAnimState = "off";
    buildingDef.ObjectLayer = ObjectLayer.Backwall;
    buildingDef.SceneLayer = Grid.SceneLayer.Backwall;
    buildingDef.ShowInBuildMenu = false;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
    go.AddComponent<ZoneTile>();
    go.GetComponent<PrimaryElement>().SetElement(SimHashes.Granite);
    go.GetComponent<PrimaryElement>().Temperature = 273f;
    go.GetComponent<KPrefabID>().AddTag(GameTags.Gravitas);
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}

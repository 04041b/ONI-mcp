// Decompiled with JetBrains decompiler
// Type: DiningTableConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class DiningTableConfig : IBuildingConfig
{
  public const string ID = "DiningTable";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR3 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
    string[] allMetals = TUNING.MATERIALS.ALL_METALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR1 = TUNING.BUILDINGS.DECOR.BONUS.TIER1;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("DiningTable", 1, 1, "diningtable_kanim", 10, 10f, tieR3, allMetals, 1600f, BuildLocationRule.OnFloor, tieR1, noise);
    buildingDef.WorkTime = 20f;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.DINING);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<LoopingSounds>();
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.DiningTableType);
    go.AddOrGet<MessStation>();
    go.AddOrGet<AnimTileable>();
    go.AddOrGetDef<RocketUsageRestriction.Def>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.GetComponent<KAnimControllerBase>().initialAnim = "off";
    Ownable ownable = go.AddOrGet<Ownable>();
    ownable.slotID = Db.Get().AssignableSlots.MessStation.Id;
    ownable.canBePublic = true;
    ownable.priority = 10;
    Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
    defaultStorage.showInUI = true;
    defaultStorage.capacityKg = TableSaltTuning.SALTSHAKERSTORAGEMASS;
    ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
    manualDeliveryKg.SetStorage(defaultStorage);
    manualDeliveryKg.RequestedItemTag = TableSaltConfig.ID.ToTag();
    manualDeliveryKg.capacity = TableSaltTuning.SALTSHAKERSTORAGEMASS;
    manualDeliveryKg.refillMass = TableSaltTuning.CONSUMABLE_RATE;
    manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.FoodFetch.IdHash;
    manualDeliveryKg.ShowStatusItem = false;
    go.AddOrGet<Reservable>();
  }
}

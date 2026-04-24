// Decompiled with JetBrains decompiler
// Type: CreatureTrapConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class CreatureTrapConfig : IBuildingConfig
{
  public const string ID = "CreatureTrap";
  private static readonly List<Storage.StoredItemModifier> StoredItemModifiers = new List<Storage.StoredItemModifier>();

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CreatureTrap", 2, 1, "creaturetrap_kanim", 10, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.PLASTICS, 1600f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER2, NOISE_POLLUTION.NOISY.TIER0);
    buildingDef.Deprecated = true;
    buildingDef.ShowInBuildMenu = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.Floodable = false;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Storage storage = go.AddOrGet<Storage>();
    storage.allowItemRemoval = true;
    storage.SetDefaultStoredItemModifiers(CreatureTrapConfig.StoredItemModifiers);
    storage.sendOnStoreOnSpawn = true;
    TrapTrigger trapTrigger = go.AddOrGet<TrapTrigger>();
    trapTrigger.trappableCreatures = new Tag[2]
    {
      GameTags.Creatures.Walker,
      GameTags.Creatures.Hoverer
    };
    trapTrigger.trappedOffset = new Vector2(0.5f, 0.0f);
    go.AddOrGet<Trap>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}

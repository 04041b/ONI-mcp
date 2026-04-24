// Decompiled with JetBrains decompiler
// Type: SculptureConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class SculptureConfig : IBuildingConfig
{
  public const string ID = "Sculpture";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] rawMinerals = TUNING.MATERIALS.RAW_MINERALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues decor = new EffectorValues()
    {
      amount = 10,
      radius = 8
    };
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("Sculpture", 1, 3, "sculpture_kanim", 30, 120f, tieR4, rawMinerals, 1600f, BuildLocationRule.OnFloor, decor, noise);
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.ViewMode = OverlayModes.Decor.ID;
    buildingDef.DefaultAnimState = "slab";
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanArt.Id;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STATUE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.ARTWORK);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.MORALE);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<BuildingComplete>().isArtable = true;
    go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddComponent<Sculpture>().defaultAnimName = "slab";
  }
}

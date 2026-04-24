// Decompiled with JetBrains decompiler
// Type: CanvasTallConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class CanvasTallConfig : IBuildingConfig
{
  public const string ID = "CanvasTall";

  public override BuildingDef CreateBuildingDef()
  {
    float[] construction_mass = new float[2]{ 400f, 1f };
    string[] construction_materials = new string[2]
    {
      "Metal",
      "BuildingFiber"
    };
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues decor = new EffectorValues()
    {
      amount = 15,
      radius = 6
    };
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CanvasTall", 2, 3, "painting_tall_off_kanim", 30, 120f, construction_mass, construction_materials, 1600f, BuildLocationRule.Anywhere, decor, noise);
    buildingDef.Floodable = false;
    buildingDef.SceneLayer = Grid.SceneLayer.InteriorWall;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.ViewMode = OverlayModes.Decor.ID;
    buildingDef.DefaultAnimState = "off";
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanArt.Id;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.MORALE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.ARTWORK);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<BuildingComplete>().isArtable = true;
    go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    SymbolOverrideControllerUtil.AddToPrefab(go);
    go.AddComponent<Painting>().defaultAnimName = "off";
  }
}

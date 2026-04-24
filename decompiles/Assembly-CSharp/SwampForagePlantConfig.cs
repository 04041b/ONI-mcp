// Decompiled with JetBrains decompiler
// Type: SwampForagePlantConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SwampForagePlantConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "SwampForagePlant";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SwampForagePlant", (string) STRINGS.ITEMS.FOOD.SWAMPFORAGEPLANT.NAME, (string) STRINGS.ITEMS.FOOD.SWAMPFORAGEPLANT.DESC, 1f, false, Assets.GetAnim((HashedString) "swamptuber_vegetable_kanim"), "object", Grid.SceneLayer.BuildingBack, EntityTemplates.CollisionShape.CIRCLE, 0.3f, 0.3f, true), TUNING.FOOD.FOOD_TYPES.SWAMPFORAGEPLANT);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

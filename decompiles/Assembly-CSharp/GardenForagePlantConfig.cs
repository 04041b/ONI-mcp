// Decompiled with JetBrains decompiler
// Type: GardenForagePlantConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GardenForagePlantConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "GardenForagePlant";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("GardenForagePlant", (string) STRINGS.ITEMS.FOOD.GARDENFORAGEPLANT.NAME, (string) STRINGS.ITEMS.FOOD.GARDENFORAGEPLANT.DESC, 1f, false, Assets.GetAnim((HashedString) "fatplantfood_kanim"), "object", Grid.SceneLayer.BuildingBack, EntityTemplates.CollisionShape.CIRCLE, 0.3f, 0.3f, true), TUNING.FOOD.FOOD_TYPES.GARDENFORAGEPLANT);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

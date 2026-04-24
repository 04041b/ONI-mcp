// Decompiled with JetBrains decompiler
// Type: WormSuperFoodConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WormSuperFoodConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "WormSuperFood";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("WormSuperFood", (string) STRINGS.ITEMS.FOOD.WORMSUPERFOOD.NAME, (string) STRINGS.ITEMS.FOOD.WORMSUPERFOOD.DESC, 1f, false, Assets.GetAnim((HashedString) "wormwood_preserved_berries_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.6f, true), TUNING.FOOD.FOOD_TYPES.WORMSUPERFOOD);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: GrilledPrickleFruitConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GrilledPrickleFruitConfig : IEntityConfig
{
  public const string ID = "GrilledPrickleFruit";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("GrilledPrickleFruit", (string) STRINGS.ITEMS.FOOD.GRILLEDPRICKLEFRUIT.NAME, (string) STRINGS.ITEMS.FOOD.GRILLEDPRICKLEFRUIT.DESC, 1f, false, Assets.GetAnim((HashedString) "gristleberry_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.7f, true), TUNING.FOOD.FOOD_TYPES.GRILLED_PRICKLEFRUIT);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

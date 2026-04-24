// Decompiled with JetBrains decompiler
// Type: FruitCakeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FruitCakeConfig : IEntityConfig
{
  public const string ID = "FruitCake";
  public const string ANIM = "fruitcake_kanim";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("FruitCake", (string) STRINGS.ITEMS.FOOD.FRUITCAKE.NAME, (string) STRINGS.ITEMS.FOOD.FRUITCAKE.DESC, 1f, false, Assets.GetAnim((HashedString) "fruitcake_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.FRUITCAKE);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

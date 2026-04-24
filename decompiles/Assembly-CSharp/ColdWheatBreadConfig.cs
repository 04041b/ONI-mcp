// Decompiled with JetBrains decompiler
// Type: ColdWheatBreadConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ColdWheatBreadConfig : IEntityConfig
{
  public const string ID = "ColdWheatBread";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("ColdWheatBread", (string) STRINGS.ITEMS.FOOD.COLDWHEATBREAD.NAME, (string) STRINGS.ITEMS.FOOD.COLDWHEATBREAD.DESC, 1f, false, Assets.GetAnim((HashedString) "frostbread_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.COLD_WHEAT_BREAD);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

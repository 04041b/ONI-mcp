// Decompiled with JetBrains decompiler
// Type: SpiceBreadConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpiceBreadConfig : IEntityConfig
{
  public const string ID = "SpiceBread";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SpiceBread", (string) STRINGS.ITEMS.FOOD.SPICEBREAD.NAME, (string) STRINGS.ITEMS.FOOD.SPICEBREAD.DESC, 1f, false, Assets.GetAnim((HashedString) "pepperbread_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.9f, 0.6f, true), TUNING.FOOD.FOOD_TYPES.SPICEBREAD);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

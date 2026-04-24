// Decompiled with JetBrains decompiler
// Type: TofuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TofuConfig : IEntityConfig
{
  public const string ID = "Tofu";
  public const string ANIM = "loafu_kanim";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Tofu", (string) STRINGS.ITEMS.FOOD.TOFU.NAME, (string) STRINGS.ITEMS.FOOD.TOFU.DESC, 1f, false, Assets.GetAnim((HashedString) "loafu_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.9f, 0.6f, true), TUNING.FOOD.FOOD_TYPES.TOFU);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: MushroomWrapConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MushroomWrapConfig : IEntityConfig
{
  public const string ID = "MushroomWrap";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MushroomWrap", (string) STRINGS.ITEMS.FOOD.MUSHROOMWRAP.NAME, (string) STRINGS.ITEMS.FOOD.MUSHROOMWRAP.DESC, 1f, false, Assets.GetAnim((HashedString) "mushroom_wrap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.5f, true), TUNING.FOOD.FOOD_TYPES.MUSHROOM_WRAP);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

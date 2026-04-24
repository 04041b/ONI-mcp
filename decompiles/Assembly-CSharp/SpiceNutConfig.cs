// Decompiled with JetBrains decompiler
// Type: SpiceNutConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class SpiceNutConfig : IEntityConfig
{
  public static float SEEDS_PER_FRUIT = 1f;
  public static string ID = "SpiceNut";

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(SpiceNutConfig.ID, (string) STRINGS.ITEMS.FOOD.SPICENUT.NAME, (string) STRINGS.ITEMS.FOOD.SPICENUT.DESC, 1f, false, Assets.GetAnim((HashedString) "spicenut_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.CIRCLE, 0.3f, 0.3f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.SPICENUT);
    SoundEventVolumeCache.instance.AddVolume("vinespicenut_kanim", "VineSpiceNut_grow", NOISE_POLLUTION.CREATURES.TIER3);
    SoundEventVolumeCache.instance.AddVolume("vinespicenut_kanim", "VineSpiceNut_harvest", NOISE_POLLUTION.CREATURES.TIER3);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

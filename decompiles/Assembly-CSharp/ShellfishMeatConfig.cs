// Decompiled with JetBrains decompiler
// Type: ShellfishMeatConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ShellfishMeatConfig : IEntityConfig
{
  public const string ID = "ShellfishMeat";

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("ShellfishMeat", (string) STRINGS.ITEMS.FOOD.SHELLFISHMEAT.NAME, (string) STRINGS.ITEMS.FOOD.SHELLFISHMEAT.DESC, 1f, false, Assets.GetAnim((HashedString) "shellfish_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.SHELLFISH_MEAT);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: LettuceConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LettuceConfig : IEntityConfig
{
  public const string ID = "Lettuce";

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Lettuce", (string) STRINGS.ITEMS.FOOD.LETTUCE.NAME, (string) STRINGS.ITEMS.FOOD.LETTUCE.DESC, 1f, false, Assets.GetAnim((HashedString) "sea_lettuce_leaves_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.LETTUCE);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: VineFruitConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class VineFruitConfig : IEntityConfig, IHasDlcRestrictions
{
  public static string ID = "VineFruit";
  public const float KCalPerUnit = 325000f;

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(VineFruitConfig.ID, (string) STRINGS.ITEMS.FOOD.VINEFRUIT.NAME, (string) STRINGS.ITEMS.FOOD.VINEFRUIT.DESC, 1f, false, Assets.GetAnim((HashedString) "ova_melon_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.VINEFRUIT);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

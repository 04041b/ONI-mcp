// Decompiled with JetBrains decompiler
// Type: HardSkinBerryConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HardSkinBerryConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "HardSkinBerry";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("HardSkinBerry", (string) STRINGS.ITEMS.FOOD.HARDSKINBERRY.NAME, (string) STRINGS.ITEMS.FOOD.HARDSKINBERRY.DESC, 1f, false, Assets.GetAnim((HashedString) "iceBerry_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.CIRCLE, 0.25f, 0.25f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.HARDSKINBERRY);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

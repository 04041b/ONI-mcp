// Decompiled with JetBrains decompiler
// Type: WormSuperFruitConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WormSuperFruitConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "WormSuperFruit";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("WormSuperFruit", (string) STRINGS.ITEMS.FOOD.WORMSUPERFRUIT.NAME, (string) STRINGS.ITEMS.FOOD.WORMSUPERFRUIT.DESC, 1f, false, Assets.GetAnim((HashedString) "wormwood_super_fruits_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.6f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.WORMSUPERFRUIT);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

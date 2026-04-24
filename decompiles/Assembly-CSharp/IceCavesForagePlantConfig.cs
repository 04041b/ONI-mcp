// Decompiled with JetBrains decompiler
// Type: IceCavesForagePlantConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class IceCavesForagePlantConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "IceCavesForagePlant";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("IceCavesForagePlant", (string) STRINGS.ITEMS.FOOD.ICECAVESFORAGEPLANT.NAME, (string) STRINGS.ITEMS.FOOD.ICECAVESFORAGEPLANT.DESC, 1f, false, Assets.GetAnim((HashedString) "frozenberries_fruit_kanim"), "object", Grid.SceneLayer.BuildingBack, EntityTemplates.CollisionShape.CIRCLE, 0.3f, 0.3f, true), TUNING.FOOD.FOOD_TYPES.ICECAVESFORAGEPLANT);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BerryPieConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BerryPieConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "BerryPie";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("BerryPie", (string) STRINGS.ITEMS.FOOD.BERRYPIE.NAME, (string) STRINGS.ITEMS.FOOD.BERRYPIE.DESC, 1f, false, Assets.GetAnim((HashedString) "wormwood_berry_pie_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.55f, true), TUNING.FOOD.FOOD_TYPES.BERRY_PIE);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

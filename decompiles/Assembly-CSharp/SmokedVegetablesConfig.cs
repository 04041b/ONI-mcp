// Decompiled with JetBrains decompiler
// Type: SmokedVegetablesConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SmokedVegetablesConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "SmokedVegetables";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SmokedVegetables", (string) STRINGS.ITEMS.FOOD.SMOKEDVEGETABLES.NAME, (string) STRINGS.ITEMS.FOOD.SMOKEDVEGETABLES.DESC, 1f, false, Assets.GetAnim((HashedString) "smokedvegetables_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.7f, true), TUNING.FOOD.FOOD_TYPES.SMOKED_VEGETABLES);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

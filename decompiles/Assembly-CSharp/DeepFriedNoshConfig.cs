// Decompiled with JetBrains decompiler
// Type: DeepFriedNoshConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DeepFriedNoshConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DeepFriedNosh";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("DeepFriedNosh", (string) STRINGS.ITEMS.FOOD.DEEPFRIEDNOSH.NAME, (string) STRINGS.ITEMS.FOOD.DEEPFRIEDNOSH.DESC, 1f, false, Assets.GetAnim((HashedString) "deepfried_nosh_beans_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.DEEP_FRIED_NOSH);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: DeepFriedShellfishConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DeepFriedShellfishConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DeepFriedShellfish";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("DeepFriedShellfish", (string) STRINGS.ITEMS.FOOD.DEEPFRIEDSHELLFISH.NAME, (string) STRINGS.ITEMS.FOOD.DEEPFRIEDSHELLFISH.DESC, 1f, false, Assets.GetAnim((HashedString) "deepfried_shellfish_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.FOOD.FOOD_TYPES.DEEP_FRIED_SHELLFISH);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

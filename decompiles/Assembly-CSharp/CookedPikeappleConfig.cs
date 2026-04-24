// Decompiled with JetBrains decompiler
// Type: CookedPikeappleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CookedPikeappleConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "CookedPikeapple";
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("CookedPikeapple", (string) STRINGS.ITEMS.FOOD.COOKEDPIKEAPPLE.NAME, (string) STRINGS.ITEMS.FOOD.COOKEDPIKEAPPLE.DESC, 1f, false, Assets.GetAnim((HashedString) "iceberry_cooked_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true), TUNING.FOOD.FOOD_TYPES.COOKED_PIKEAPPLE);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

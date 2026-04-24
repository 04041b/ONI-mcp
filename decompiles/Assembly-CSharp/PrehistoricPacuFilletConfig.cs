// Decompiled with JetBrains decompiler
// Type: PrehistoricPacuFilletConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PrehistoricPacuFilletConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "PrehistoricPacuFillet";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("PrehistoricPacuFillet", (string) STRINGS.ITEMS.FOOD.PREHISTORICPACUFILLET.NAME, (string) STRINGS.ITEMS.FOOD.PREHISTORICPACUFILLET.DESC, 1f, false, Assets.GetAnim((HashedString) "jawboFillet_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.JAWBOFILLET);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

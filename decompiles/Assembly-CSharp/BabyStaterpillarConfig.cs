// Decompiled with JetBrains decompiler
// Type: BabyStaterpillarConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyStaterpillarConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "StaterpillarBaby";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject staterpillar = StaterpillarConfig.CreateStaterpillar("StaterpillarBaby", (string) CREATURES.SPECIES.STATERPILLAR.BABY.NAME, (string) CREATURES.SPECIES.STATERPILLAR.BABY.DESC, "baby_caterpillar_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(staterpillar, (Tag) "Staterpillar");
    return staterpillar;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

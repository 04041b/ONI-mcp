// Decompiled with JetBrains decompiler
// Type: BabyGoldBellyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyGoldBellyConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "GoldBellyBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject goldBelly = GoldBellyConfig.CreateGoldBelly("GoldBellyBaby", (string) CREATURES.SPECIES.ICEBELLY.VARIANT_GOLD.BABY.NAME, (string) CREATURES.SPECIES.ICEBELLY.VARIANT_GOLD.BABY.DESC, "baby_icebelly_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(goldBelly, (Tag) "GoldBelly").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * GoldBellyConfig.SCALE_INITIAL_GROWTH_PCT;
    });
    return goldBelly;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

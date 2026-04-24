// Decompiled with JetBrains decompiler
// Type: BabyRaptorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyRaptorConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "RaptorBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject raptor = RaptorConfig.CreateRaptor("RaptorBaby", (string) CREATURES.SPECIES.RAPTOR.BABY.NAME, (string) CREATURES.SPECIES.RAPTOR.BABY.DESC, "baby_raptor_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(raptor, (Tag) "Raptor").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * RaptorConfig.SCALE_INITIAL_GROWTH_PCT;
    });
    return raptor;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

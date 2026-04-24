// Decompiled with JetBrains decompiler
// Type: BabyIceBellyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyIceBellyConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "IceBellyBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject iceBelly = IceBellyConfig.CreateIceBelly("IceBellyBaby", (string) CREATURES.SPECIES.ICEBELLY.BABY.NAME, (string) CREATURES.SPECIES.ICEBELLY.BABY.DESC, "baby_icebelly_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(iceBelly, (Tag) "IceBelly").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * IceBellyConfig.SCALE_INITIAL_GROWTH_PCT;
    });
    return iceBelly;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

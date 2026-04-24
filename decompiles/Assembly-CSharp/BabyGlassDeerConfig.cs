// Decompiled with JetBrains decompiler
// Type: BabyGlassDeerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyGlassDeerConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "GlassDeerBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject glassDeer = GlassDeerConfig.CreateGlassDeer("GlassDeerBaby", (string) CREATURES.SPECIES.GLASSDEER.BABY.NAME, (string) CREATURES.SPECIES.GLASSDEER.BABY.DESC, "baby_ice_floof_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(glassDeer, (Tag) "GlassDeer").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * 0.5f;
    });
    return glassDeer;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

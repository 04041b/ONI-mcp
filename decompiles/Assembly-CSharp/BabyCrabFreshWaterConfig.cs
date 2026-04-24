// Decompiled with JetBrains decompiler
// Type: BabyCrabFreshWaterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyCrabFreshWaterConfig : IEntityConfig
{
  public const string ID = "CrabFreshWaterBaby";

  public GameObject CreatePrefab()
  {
    GameObject crabFreshWater = CrabFreshWaterConfig.CreateCrabFreshWater("CrabFreshWaterBaby", (string) CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.BABY.NAME, (string) CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.BABY.DESC, "baby_pincher_kanim", true, "ShellfishMeat", 4);
    EntityTemplates.ExtendEntityToBeingABaby(crabFreshWater, (Tag) "CrabFreshWater");
    return crabFreshWater;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

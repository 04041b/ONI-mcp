// Decompiled with JetBrains decompiler
// Type: BabyDreckoPlasticConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyDreckoPlasticConfig : IEntityConfig
{
  public const string ID = "DreckoPlasticBaby";

  public GameObject CreatePrefab()
  {
    GameObject drecko = DreckoPlasticConfig.CreateDrecko("DreckoPlasticBaby", (string) CREATURES.SPECIES.DRECKO.VARIANT_PLASTIC.BABY.NAME, (string) CREATURES.SPECIES.DRECKO.VARIANT_PLASTIC.BABY.DESC, "baby_drecko_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(drecko, (Tag) "DreckoPlastic");
    return drecko;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

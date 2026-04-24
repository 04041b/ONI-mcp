// Decompiled with JetBrains decompiler
// Type: BabyHatchVeggieConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyHatchVeggieConfig : IEntityConfig
{
  public const string ID = "HatchVeggieBaby";

  public GameObject CreatePrefab()
  {
    GameObject hatch = HatchVeggieConfig.CreateHatch("HatchVeggieBaby", (string) CREATURES.SPECIES.HATCH.VARIANT_VEGGIE.BABY.NAME, (string) CREATURES.SPECIES.HATCH.VARIANT_VEGGIE.BABY.DESC, "baby_hatch_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(hatch, (Tag) "HatchVeggie");
    return hatch;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

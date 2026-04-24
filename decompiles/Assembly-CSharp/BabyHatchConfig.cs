// Decompiled with JetBrains decompiler
// Type: BabyHatchConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyHatchConfig : IEntityConfig
{
  public const string ID = "HatchBaby";

  public GameObject CreatePrefab()
  {
    GameObject hatch = HatchConfig.CreateHatch("HatchBaby", (string) CREATURES.SPECIES.HATCH.BABY.NAME, (string) CREATURES.SPECIES.HATCH.BABY.DESC, "baby_hatch_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(hatch, (Tag) "Hatch");
    return hatch;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BabyPacuTropicalConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyPacuTropicalConfig : IEntityConfig
{
  public const string ID = "PacuTropicalBaby";

  public GameObject CreatePrefab()
  {
    GameObject pacu = PacuTropicalConfig.CreatePacu("PacuTropicalBaby", (string) CREATURES.SPECIES.PACU.VARIANT_TROPICAL.BABY.NAME, (string) CREATURES.SPECIES.PACU.VARIANT_TROPICAL.BABY.DESC, "baby_pacu_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(pacu, (Tag) "PacuTropical");
    return pacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

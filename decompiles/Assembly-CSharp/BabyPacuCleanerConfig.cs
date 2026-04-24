// Decompiled with JetBrains decompiler
// Type: BabyPacuCleanerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyPacuCleanerConfig : IEntityConfig
{
  public const string ID = "PacuCleanerBaby";

  public GameObject CreatePrefab()
  {
    GameObject pacu = PacuCleanerConfig.CreatePacu("PacuCleanerBaby", (string) CREATURES.SPECIES.PACU.VARIANT_CLEANER.BABY.NAME, (string) CREATURES.SPECIES.PACU.VARIANT_CLEANER.BABY.DESC, "baby_pacu_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(pacu, (Tag) "PacuCleaner");
    return pacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BabyPuftBleachstoneConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyPuftBleachstoneConfig : IEntityConfig
{
  public const string ID = "PuftBleachstoneBaby";

  public GameObject CreatePrefab()
  {
    GameObject puftBleachstone = PuftBleachstoneConfig.CreatePuftBleachstone("PuftBleachstoneBaby", (string) CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.BABY.NAME, (string) CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.BABY.DESC, "baby_puft_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(puftBleachstone, (Tag) "PuftBleachstone");
    return puftBleachstone;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst) => BasePuftConfig.OnSpawn(inst);
}

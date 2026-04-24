// Decompiled with JetBrains decompiler
// Type: BabyPuftOxyliteConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyPuftOxyliteConfig : IEntityConfig
{
  public const string ID = "PuftOxyliteBaby";

  public GameObject CreatePrefab()
  {
    GameObject puftOxylite = PuftOxyliteConfig.CreatePuftOxylite("PuftOxyliteBaby", (string) CREATURES.SPECIES.PUFT.VARIANT_OXYLITE.BABY.NAME, (string) CREATURES.SPECIES.PUFT.VARIANT_OXYLITE.BABY.DESC, "baby_puft_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(puftOxylite, (Tag) "PuftOxylite");
    return puftOxylite;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

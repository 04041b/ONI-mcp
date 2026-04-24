// Decompiled with JetBrains decompiler
// Type: BabyPuftConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyPuftConfig : IEntityConfig
{
  public const string ID = "PuftBaby";

  public GameObject CreatePrefab()
  {
    GameObject puft = PuftConfig.CreatePuft("PuftBaby", (string) CREATURES.SPECIES.PUFT.BABY.NAME, (string) CREATURES.SPECIES.PUFT.BABY.DESC, "baby_puft_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(puft, (Tag) "Puft");
    return puft;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BabySealConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabySealConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "SealBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject seal = SealConfig.CreateSeal("SealBaby", (string) CREATURES.SPECIES.SEAL.BABY.NAME, (string) CREATURES.SPECIES.SEAL.BABY.DESC, "baby_seal_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(seal, (Tag) "Seal");
    return seal;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

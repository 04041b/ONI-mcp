// Decompiled with JetBrains decompiler
// Type: BabyStegoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyStegoConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "StegoBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject stego = StegoConfig.CreateStego("StegoBaby", (string) CREATURES.SPECIES.STEGO.BABY.NAME, (string) CREATURES.SPECIES.STEGO.BABY.DESC, "baby_stego_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(stego, (Tag) "Stego");
    return stego;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

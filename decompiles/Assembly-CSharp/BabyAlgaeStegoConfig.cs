// Decompiled with JetBrains decompiler
// Type: BabyAlgaeStegoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyAlgaeStegoConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "AlgaeStegoBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject stego = AlgaeStegoConfig.CreateStego("AlgaeStegoBaby", (string) CREATURES.SPECIES.ALGAE_STEGO.BABY.NAME, (string) CREATURES.SPECIES.ALGAE_STEGO.BABY.DESC, "baby_stego_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(stego, (Tag) "AlgaeStego");
    KBatchedAnimController component = stego.GetComponent<KBatchedAnimController>();
    component.SetSymbolVisiblity((KAnimHashedString) "baby_stego_eye_yellow", false);
    component.SetSymbolVisiblity((KAnimHashedString) "baby_stego_scale", false);
    component.SetSymbolVisiblity((KAnimHashedString) "baby_stego_pupil", false);
    return stego;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BabyPrehistoricPacuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabyPrehistoricPacuConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "PrehistoricPacuBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject prehistoricPacu = PrehistoricPacuConfig.CreatePrehistoricPacu("PrehistoricPacuBaby", (string) CREATURES.SPECIES.PREHISTORICPACU.BABY.NAME, (string) CREATURES.SPECIES.PREHISTORICPACU.BABY.DESC, "baby_paculacanth_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(prehistoricPacu, (Tag) "PrehistoricPacu");
    return prehistoricPacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: MosquitoLarvaConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class MosquitoLarvaConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "MosquitoBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject mosquito = MosquitoConfig.CreateMosquito("MosquitoBaby", (string) CREATURES.SPECIES.MOSQUITO.BABY.NAME, (string) CREATURES.SPECIES.MOSQUITO.BABY.DESC, "baby_mosquito_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(mosquito, (Tag) "Mosquito");
    return mosquito;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

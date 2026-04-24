// Decompiled with JetBrains decompiler
// Type: OilFloaterBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class OilFloaterBabyConfig : IEntityConfig
{
  public const string ID = "OilfloaterBaby";

  public GameObject CreatePrefab()
  {
    GameObject oilFloater = OilFloaterConfig.CreateOilFloater("OilfloaterBaby", (string) CREATURES.SPECIES.OILFLOATER.BABY.NAME, (string) CREATURES.SPECIES.OILFLOATER.BABY.DESC, "baby_oilfloater_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(oilFloater, (Tag) "Oilfloater");
    return oilFloater;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

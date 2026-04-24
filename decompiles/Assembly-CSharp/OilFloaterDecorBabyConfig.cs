// Decompiled with JetBrains decompiler
// Type: OilFloaterDecorBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class OilFloaterDecorBabyConfig : IEntityConfig
{
  public const string ID = "OilfloaterDecorBaby";

  public GameObject CreatePrefab()
  {
    GameObject oilFloater = OilFloaterDecorConfig.CreateOilFloater("OilfloaterDecorBaby", (string) CREATURES.SPECIES.OILFLOATER.VARIANT_DECOR.BABY.NAME, (string) CREATURES.SPECIES.OILFLOATER.VARIANT_DECOR.BABY.DESC, "baby_oilfloater_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(oilFloater, (Tag) "OilfloaterDecor");
    return oilFloater;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

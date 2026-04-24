// Decompiled with JetBrains decompiler
// Type: LightBugCrystalBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class LightBugCrystalBabyConfig : IEntityConfig
{
  public const string ID = "LightBugCrystalBaby";

  public GameObject CreatePrefab()
  {
    GameObject lightBug = LightBugCrystalConfig.CreateLightBug("LightBugCrystalBaby", (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_CRYSTAL.BABY.NAME, (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_CRYSTAL.BABY.DESC, "baby_lightbug_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(lightBug, (Tag) "LightBugCrystal");
    return lightBug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

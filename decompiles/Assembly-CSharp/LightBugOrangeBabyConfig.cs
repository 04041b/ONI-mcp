// Decompiled with JetBrains decompiler
// Type: LightBugOrangeBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class LightBugOrangeBabyConfig : IEntityConfig
{
  public const string ID = "LightBugOrangeBaby";

  public GameObject CreatePrefab()
  {
    GameObject lightBug = LightBugOrangeConfig.CreateLightBug("LightBugOrangeBaby", (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_ORANGE.BABY.NAME, (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_ORANGE.BABY.DESC, "baby_lightbug_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(lightBug, (Tag) "LightBugOrange");
    return lightBug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

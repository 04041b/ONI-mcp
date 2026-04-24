// Decompiled with JetBrains decompiler
// Type: LightBugBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class LightBugBabyConfig : IEntityConfig
{
  public const string ID = "LightBugBaby";

  public GameObject CreatePrefab()
  {
    GameObject lightBug = LightBugConfig.CreateLightBug("LightBugBaby", (string) CREATURES.SPECIES.LIGHTBUG.BABY.NAME, (string) CREATURES.SPECIES.LIGHTBUG.BABY.DESC, "baby_lightbug_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(lightBug, (Tag) "LightBug");
    return lightBug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

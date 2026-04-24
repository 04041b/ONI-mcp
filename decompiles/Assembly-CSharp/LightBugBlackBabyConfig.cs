// Decompiled with JetBrains decompiler
// Type: LightBugBlackBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class LightBugBlackBabyConfig : IEntityConfig
{
  public const string ID = "LightBugBlackBaby";

  public GameObject CreatePrefab()
  {
    GameObject lightBug = LightBugBlackConfig.CreateLightBug("LightBugBlackBaby", (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_BLACK.BABY.NAME, (string) CREATURES.SPECIES.LIGHTBUG.VARIANT_BLACK.BABY.DESC, "baby_lightbug_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(lightBug, (Tag) "LightBugBlack");
    return lightBug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

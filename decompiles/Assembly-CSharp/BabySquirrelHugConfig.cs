// Decompiled with JetBrains decompiler
// Type: BabySquirrelHugConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabySquirrelHugConfig : IEntityConfig
{
  public const string ID = "SquirrelHugBaby";

  public GameObject CreatePrefab()
  {
    GameObject squirrelHug = SquirrelHugConfig.CreateSquirrelHug("SquirrelHugBaby", (string) CREATURES.SPECIES.SQUIRREL.VARIANT_HUG.BABY.NAME, (string) CREATURES.SPECIES.SQUIRREL.VARIANT_HUG.BABY.DESC, "baby_squirrel_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(squirrelHug, (Tag) "SquirrelHug");
    return squirrelHug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

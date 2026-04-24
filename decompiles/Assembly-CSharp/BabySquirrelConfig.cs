// Decompiled with JetBrains decompiler
// Type: BabySquirrelConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(3)]
public class BabySquirrelConfig : IEntityConfig
{
  public const string ID = "SquirrelBaby";

  public GameObject CreatePrefab()
  {
    GameObject squirrel = SquirrelConfig.CreateSquirrel("SquirrelBaby", (string) CREATURES.SPECIES.SQUIRREL.BABY.NAME, (string) CREATURES.SPECIES.SQUIRREL.BABY.DESC, "baby_squirrel_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(squirrel, (Tag) "Squirrel");
    return squirrel;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

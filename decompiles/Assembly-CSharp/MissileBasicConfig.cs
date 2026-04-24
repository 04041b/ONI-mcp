// Decompiled with JetBrains decompiler
// Type: MissileBasicConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MissileBasicConfig : IEntityConfig
{
  public const string ID = "MissileBasic";
  public const float MASS_PER_MISSILE = 10f;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("MissileBasic", (string) ITEMS.MISSILE_BASIC.NAME, (string) ITEMS.MISSILE_BASIC.DESC, 10f, true, Assets.GetAnim((HashedString) "missile_kanim"), "object", Grid.SceneLayer.Ore, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, element: SimHashes.Iron, additionalTags: new List<Tag>()
    {
      GameTags.PedestalDisplayable
    });
    looseEntity.AddTag(GameTags.IndustrialProduct);
    looseEntity.AddOrGetDef<MissileProjectile.Def>();
    looseEntity.AddOrGet<EntitySplitter>().maxStackSize = 50f;
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

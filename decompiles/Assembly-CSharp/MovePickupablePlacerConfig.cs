// Decompiled with JetBrains decompiler
// Type: MovePickupablePlacerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class MovePickupablePlacerConfig : CommonPlacerConfig, IEntityConfig
{
  public static string ID = "MovePickupablePlacer";

  public GameObject CreatePrefab()
  {
    GameObject prefab = this.CreatePrefab(MovePickupablePlacerConfig.ID, (string) MISC.PLACERS.MOVEPICKUPABLEPLACER.NAME, Assets.instance.movePickupToPlacerAssets.material);
    prefab.AddOrGet<CancellableMove>();
    Storage storage = prefab.AddOrGet<Storage>();
    storage.showInUI = false;
    storage.showUnreachableStatus = true;
    prefab.AddOrGet<Approachable>();
    prefab.AddOrGet<Prioritizable>();
    prefab.AddTag(GameTags.NotConversationTopic);
    return prefab;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }

  [Serializable]
  public class MovePickupablePlacerAssets
  {
    public Material material;
  }
}

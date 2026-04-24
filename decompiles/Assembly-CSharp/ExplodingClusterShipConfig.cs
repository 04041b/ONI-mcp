// Decompiled with JetBrains decompiler
// Type: ExplodingClusterShipConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ExplodingClusterShipConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "ExplodingClusterShip";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity("ExplodingClusterShip", "ExplodingClusterShip", false);
    ClusterFXEntity clusterFxEntity = entity.AddOrGet<ClusterFXEntity>();
    clusterFxEntity.kAnimName = "rocket_self_destruct_kanim";
    clusterFxEntity.animName = "explode";
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

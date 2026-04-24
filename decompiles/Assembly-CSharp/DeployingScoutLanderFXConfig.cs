// Decompiled with JetBrains decompiler
// Type: DeployingScoutLanderFXConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DeployingScoutLanderFXConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DeployingScoutLanderFXConfig";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(nameof (DeployingScoutLanderFXConfig), nameof (DeployingScoutLanderFXConfig), false);
    ClusterFXEntity clusterFxEntity = entity.AddOrGet<ClusterFXEntity>();
    clusterFxEntity.kAnimName = "rover01_kanim";
    clusterFxEntity.animName = "landing";
    clusterFxEntity.animPlayMode = KAnim.PlayMode.Loop;
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

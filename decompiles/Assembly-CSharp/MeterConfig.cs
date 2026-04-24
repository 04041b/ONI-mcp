// Decompiled with JetBrains decompiler
// Type: MeterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MeterConfig : IEntityConfig
{
  public static readonly string ID = "Meter";

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(MeterConfig.ID, MeterConfig.ID, false);
    entity.AddOrGet<KBatchedAnimController>();
    entity.AddOrGet<KBatchedAnimTracker>();
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}

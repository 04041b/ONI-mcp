// Decompiled with JetBrains decompiler
// Type: RepairableStorageProxy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RepairableStorageProxy : IEntityConfig
{
  public static string ID = nameof (RepairableStorageProxy);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(RepairableStorageProxy.ID, RepairableStorageProxy.ID);
    entity.AddOrGet<Storage>();
    entity.AddTag(GameTags.NotConversationTopic);
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}

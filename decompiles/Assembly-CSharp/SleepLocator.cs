// Decompiled with JetBrains decompiler
// Type: SleepLocator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SleepLocator : IEntityConfig
{
  public static readonly string ID = nameof (SleepLocator);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(SleepLocator.ID, SleepLocator.ID, false);
    entity.AddTag(GameTags.NotConversationTopic);
    entity.AddOrGet<Approachable>();
    entity.AddOrGet<Sleepable>().isNormalBed = false;
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}

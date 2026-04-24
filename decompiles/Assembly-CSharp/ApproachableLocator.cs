// Decompiled with JetBrains decompiler
// Type: ApproachableLocator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ApproachableLocator : IEntityConfig
{
  public static readonly string ID = nameof (ApproachableLocator);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(ApproachableLocator.ID, ApproachableLocator.ID, false);
    entity.AddTag(GameTags.NotConversationTopic);
    entity.AddOrGet<Approachable>();
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}

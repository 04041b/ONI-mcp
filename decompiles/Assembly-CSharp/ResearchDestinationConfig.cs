// Decompiled with JetBrains decompiler
// Type: ResearchDestinationConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ResearchDestinationConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "ResearchDestination";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity("ResearchDestination", "ResearchDestination");
    entity.AddOrGet<SaveLoadRoot>();
    entity.AddOrGet<ResearchDestination>();
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

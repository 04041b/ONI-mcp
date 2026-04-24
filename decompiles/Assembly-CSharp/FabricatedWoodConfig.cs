// Decompiled with JetBrains decompiler
// Type: FabricatedWoodConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FabricatedWoodConfig : IOreConfig
{
  public const string ID = "FabricatedWood";
  public static readonly Tag TAG = TagManager.Create("FabricatedWood");

  public SimHashes ElementID => SimHashes.FabricatedWood;

  public GameObject CreatePrefab()
  {
    GameObject solidOreEntity = EntityTemplates.CreateSolidOreEntity(this.ElementID);
    solidOreEntity.GetComponent<KPrefabID>().RemoveTag(GameTags.HideFromSpawnTool);
    return solidOreEntity;
  }
}

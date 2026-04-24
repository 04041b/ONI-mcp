// Decompiled with JetBrains decompiler
// Type: FishFeederBotConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FishFeederBotConfig : IEntityConfig
{
  public const string ID = "FishFeederBot";

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity("FishFeederBot", "FishFeederBot");
    KBatchedAnimController kbatchedAnimController = entity.AddOrGet<KBatchedAnimController>();
    kbatchedAnimController.AnimFiles = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "fishfeeder_kanim")
    };
    kbatchedAnimController.sceneLayer = Grid.SceneLayer.BuildingBack;
    SymbolOverrideControllerUtil.AddToPrefab(kbatchedAnimController.gameObject);
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

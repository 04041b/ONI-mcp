// Decompiled with JetBrains decompiler
// Type: NuclearWasteConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NuclearWasteConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.NuclearWaste;

  public GameObject CreatePrefab()
  {
    GameObject liquidOreEntity = EntityTemplates.CreateLiquidOreEntity(this.ElementID);
    Sublimates sublimates = liquidOreEntity.AddOrGet<Sublimates>();
    sublimates.decayStorage = true;
    sublimates.spawnFXHash = SpawnFXHashes.NuclearWasteDrip;
    sublimates.info = new Sublimates.Info(0.066f, 6.6f, 1000f, 0.0f, this.ElementID);
    return liquidOreEntity;
  }
}

// Decompiled with JetBrains decompiler
// Type: ForestTreeSeedMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
public class ForestTreeSeedMonitor : KMonoBehaviour
{
  [Serialize]
  private bool hasExtraSeedAvailable;

  public bool ExtraSeedAvailable => this.hasExtraSeedAvailable;

  public void ExtractExtraSeed()
  {
    if (!this.hasExtraSeedAvailable)
      return;
    this.hasExtraSeedAvailable = false;
    Vector3 position = this.transform.position with
    {
      z = Grid.GetLayerZ(Grid.SceneLayer.Ore)
    };
    Util.KInstantiate(Assets.GetPrefab((Tag) "ForestTreeSeed"), position).SetActive(true);
  }

  public void TryRollNewSeed()
  {
    if (this.hasExtraSeedAvailable || Random.Range(0, 100) >= 5)
      return;
    this.hasExtraSeedAvailable = true;
  }
}

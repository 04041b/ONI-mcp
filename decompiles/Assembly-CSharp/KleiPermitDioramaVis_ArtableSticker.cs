// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_ArtableSticker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using UnityEngine;

#nullable disable
public class KleiPermitDioramaVis_ArtableSticker : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private KBatchedAnimController buildingKAnim;

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
    SymbolOverrideControllerUtil.AddToPrefab(this.buildingKAnim.gameObject);
  }

  public void ConfigureWith(PermitResource permit)
  {
    KleiPermitVisUtil.ConfigureToRenderBuilding(this.buildingKAnim, (DbStickerBomb) permit);
  }
}

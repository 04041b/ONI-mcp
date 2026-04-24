// Decompiled with JetBrains decompiler
// Type: PlanStamp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/PlanStamp")]
public class PlanStamp : KMonoBehaviour
{
  public PlanStamp.StampArt stampSprites;
  [SerializeField]
  private Image StampImage;
  [SerializeField]
  private Text StampText;

  public void SetStamp(Sprite sprite, string Text)
  {
    this.StampImage.sprite = sprite;
    this.StampText.text = Text.ToUpper();
  }

  [Serializable]
  public struct StampArt
  {
    public Sprite UnderConstruction;
    public Sprite NeedsResearch;
    public Sprite SelectResource;
    public Sprite NeedsRepair;
    public Sprite NeedsPower;
    public Sprite NeedsResource;
    public Sprite NeedsGasPipe;
    public Sprite NeedsLiquidPipe;
  }
}

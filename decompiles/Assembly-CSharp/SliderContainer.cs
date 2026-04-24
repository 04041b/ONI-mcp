// Decompiled with JetBrains decompiler
// Type: SliderContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SliderContainer")]
public class SliderContainer : KMonoBehaviour
{
  public bool isPercentValue = true;
  public KSlider slider;
  public LocText nameLabel;
  public LocText valueLabel;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.slider.onValueChanged.AddListener(new UnityAction<float>(this.UpdateSliderLabel));
  }

  public void UpdateSliderLabel(float newValue)
  {
    if (this.isPercentValue)
      this.valueLabel.text = (newValue * 100f).ToString("F0") + "%";
    else
      this.valueLabel.text = newValue.ToString();
  }
}

// Decompiled with JetBrains decompiler
// Type: IActivationRangeTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IActivationRangeTarget
{
  float ActivateValue { get; set; }

  float DeactivateValue { get; set; }

  float MinValue { get; }

  float MaxValue { get; }

  bool UseWholeNumbers { get; }

  string ActivationRangeTitleText { get; }

  string ActivateSliderLabelText { get; }

  string DeactivateSliderLabelText { get; }

  string ActivateTooltip { get; }

  string DeactivateTooltip { get; }
}

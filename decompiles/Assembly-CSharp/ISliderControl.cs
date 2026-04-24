// Decompiled with JetBrains decompiler
// Type: ISliderControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface ISliderControl
{
  string SliderTitleKey { get; }

  string SliderUnits { get; }

  int SliderDecimalPlaces(int index);

  float GetSliderMin(int index);

  float GetSliderMax(int index);

  float GetSliderValue(int index);

  void SetSliderValue(float percent, int index);

  string GetSliderTooltipKey(int index);

  string GetSliderTooltip(int index);
}

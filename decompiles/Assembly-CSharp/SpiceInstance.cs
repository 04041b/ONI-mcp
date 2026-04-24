// Decompiled with JetBrains decompiler
// Type: SpiceInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;

#nullable disable
[Serializable]
public struct SpiceInstance
{
  public Tag Id;
  public float TotalKG;

  public AttributeModifier CalorieModifier
  {
    get => SpiceGrinder.SettingOptions[this.Id].Spice.CalorieModifier;
  }

  public AttributeModifier FoodModifier => SpiceGrinder.SettingOptions[this.Id].Spice.FoodModifier;

  public Effect StatBonus => SpiceGrinder.SettingOptions[this.Id].StatBonus;
}

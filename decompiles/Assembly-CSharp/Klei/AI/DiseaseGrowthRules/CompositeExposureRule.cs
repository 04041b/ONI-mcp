// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.CompositeExposureRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class CompositeExposureRule
{
  public string name;
  public float populationHalfLife;

  public string Name() => this.name;

  public void Overlay(ExposureRule rule)
  {
    if (rule.populationHalfLife.HasValue)
      this.populationHalfLife = rule.populationHalfLife.Value;
    this.name = rule.Name();
  }

  public float GetHalfLifeForCount(int count) => this.populationHalfLife;
}

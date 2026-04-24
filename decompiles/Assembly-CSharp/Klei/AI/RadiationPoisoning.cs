// Decompiled with JetBrains decompiler
// Type: Klei.AI.RadiationPoisoning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI.DiseaseGrowthRules;

#nullable disable
namespace Klei.AI;

public class RadiationPoisoning(bool statsOnly) : Disease("RadiationSickness", 100f, Disease.RangeInfo.Idempotent(), Disease.RangeInfo.Idempotent(), Disease.RangeInfo.Idempotent(), Disease.RangeInfo.Idempotent(), 0.0f, statsOnly)
{
  public const string ID = "RadiationSickness";

  protected override void PopulateElemGrowthInfo()
  {
    this.InitializeElemGrowthArray(ref this.elemGrowthInfo, Disease.DEFAULT_GROWTH_INFO);
    this.AddGrowthRule(new GrowthRule()
    {
      underPopulationDeathRate = new float?(0.0f),
      minCountPerKG = new float?(0.0f),
      populationHalfLife = new float?(600f),
      maxCountPerKG = new float?(float.PositiveInfinity),
      overPopulationHalfLife = new float?(600f),
      minDiffusionCount = new int?(10000),
      diffusionScale = new float?(0.0f),
      minDiffusionInfestationTickCount = new byte?((byte) 1)
    });
    this.InitializeElemExposureArray(ref this.elemExposureInfo, Disease.DEFAULT_EXPOSURE_INFO);
  }
}

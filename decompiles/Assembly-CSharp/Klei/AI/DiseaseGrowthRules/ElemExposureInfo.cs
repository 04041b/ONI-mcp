// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.ElemExposureInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public struct ElemExposureInfo
{
  public float populationHalfLife;

  public void Write(BinaryWriter writer) => writer.Write(this.populationHalfLife);

  public static void SetBulk(
    ElemExposureInfo[] info,
    Func<Element, bool> test,
    ElemExposureInfo settings)
  {
    List<Element> elements = ElementLoader.elements;
    for (int index = 0; index < elements.Count; ++index)
    {
      if (test(elements[index]))
        info[index] = settings;
    }
  }

  public float CalculateExposureDiseaseCountDelta(int disease_count, float dt)
  {
    return (Klei.AI.Disease.HalfLifeToGrowthRate(this.populationHalfLife, dt) - 1f) * (float) disease_count;
  }
}

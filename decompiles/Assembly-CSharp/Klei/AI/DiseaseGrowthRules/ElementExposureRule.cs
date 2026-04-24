// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.ElementExposureRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class ElementExposureRule : ExposureRule
{
  public SimHashes element;

  public ElementExposureRule(SimHashes element) => this.element = element;

  public override bool Test(Element e) => e.id == this.element;

  public override string Name() => ElementLoader.FindElementByHash(this.element).name;
}

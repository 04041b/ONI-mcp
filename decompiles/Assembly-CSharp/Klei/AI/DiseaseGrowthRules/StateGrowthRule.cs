// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.StateGrowthRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class StateGrowthRule : GrowthRule
{
  public Element.State state;

  public StateGrowthRule(Element.State state) => this.state = state;

  public override bool Test(Element e) => e.IsState(this.state);

  public override string Name() => Element.GetStateString(this.state);
}

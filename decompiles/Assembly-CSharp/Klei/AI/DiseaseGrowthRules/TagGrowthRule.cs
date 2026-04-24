// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.TagGrowthRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class TagGrowthRule : GrowthRule
{
  public Tag tag;

  public TagGrowthRule(Tag tag) => this.tag = tag;

  public override bool Test(Element e) => e.HasTag(this.tag);

  public override string Name() => this.tag.ProperName();
}

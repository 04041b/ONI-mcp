// Decompiled with JetBrains decompiler
// Type: CaloriesDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class CaloriesDisplayer : StandardAmountDisplayer
{
  public CaloriesDisplayer()
    : base(GameUtil.UnitClass.Calories, GameUtil.TimeSlice.PerCycle)
  {
    this.formatter = (StandardAttributeFormatter) new CaloriesDisplayer.CaloriesAttributeFormatter();
  }

  public class CaloriesAttributeFormatter : StandardAttributeFormatter
  {
    public CaloriesAttributeFormatter()
      : base(GameUtil.UnitClass.Calories, GameUtil.TimeSlice.PerCycle)
    {
    }

    public override string GetFormattedModifier(AttributeModifier modifier)
    {
      return modifier.IsMultiplier ? GameUtil.GetFormattedPercent((float) (-(double) modifier.Value * 100.0)) : base.GetFormattedModifier(modifier);
    }
  }
}

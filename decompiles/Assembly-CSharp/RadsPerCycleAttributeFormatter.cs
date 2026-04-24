// Decompiled with JetBrains decompiler
// Type: RadsPerCycleAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class RadsPerCycleAttributeFormatter : StandardAttributeFormatter
{
  public RadsPerCycleAttributeFormatter()
    : base(GameUtil.UnitClass.Radiation, GameUtil.TimeSlice.PerCycle)
  {
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.GetFormattedValue(instance.GetTotalDisplayValue(), GameUtil.TimeSlice.PerCycle);
  }

  public override string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice)
  {
    return base.GetFormattedValue(value / 600f, timeSlice);
  }
}

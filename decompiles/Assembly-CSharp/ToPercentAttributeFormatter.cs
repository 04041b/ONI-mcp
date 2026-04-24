// Decompiled with JetBrains decompiler
// Type: ToPercentAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class ToPercentAttributeFormatter : StandardAttributeFormatter
{
  public float max = 1f;

  public ToPercentAttributeFormatter(float max, GameUtil.TimeSlice deltaTimeSlice = GameUtil.TimeSlice.None)
    : base(GameUtil.UnitClass.Percent, deltaTimeSlice)
  {
    this.max = max;
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.GetFormattedValue(instance.GetTotalDisplayValue(), this.DeltaTimeSlice);
  }

  public override string GetFormattedModifier(AttributeModifier modifier)
  {
    return this.GetFormattedValue(modifier.Value, this.DeltaTimeSlice);
  }

  public override string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice)
  {
    return GameUtil.GetFormattedPercent((float) ((double) value / (double) this.max * 100.0), timeSlice);
  }
}

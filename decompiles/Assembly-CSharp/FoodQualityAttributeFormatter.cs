// Decompiled with JetBrains decompiler
// Type: FoodQualityAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class FoodQualityAttributeFormatter : StandardAttributeFormatter
{
  public FoodQualityAttributeFormatter()
    : base(GameUtil.UnitClass.SimpleInteger, GameUtil.TimeSlice.None)
  {
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.GetFormattedValue(instance.GetTotalDisplayValue());
  }

  public override string GetFormattedModifier(AttributeModifier modifier)
  {
    return GameUtil.GetFormattedInt(modifier.Value);
  }

  public override string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice)
  {
    return Util.StripTextFormatting(GameUtil.GetFormattedFoodQuality((int) value));
  }
}

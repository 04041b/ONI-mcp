// Decompiled with JetBrains decompiler
// Type: QualityOfLifeAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Text;

#nullable disable
public class QualityOfLifeAttributeFormatter : StandardAttributeFormatter
{
  public QualityOfLifeAttributeFormatter()
    : base(GameUtil.UnitClass.SimpleInteger, GameUtil.TimeSlice.None)
  {
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    AttributeInstance attributeInstance = Db.Get().Attributes.QualityOfLifeExpectation.Lookup(instance.gameObject);
    return string.Format((string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.DESC_FORMAT, (object) this.GetFormattedValue(instance.GetTotalDisplayValue()), (object) this.GetFormattedValue(attributeInstance.GetTotalDisplayValue()));
  }

  public override string GetTooltip(Attribute master, AttributeInstance instance)
  {
    StringBuilder sb = GlobalStringBuilderPool.Alloc();
    sb.Append(base.GetTooltip(master, instance));
    AttributeInstance attributeInstance = Db.Get().Attributes.QualityOfLifeExpectation.Lookup(instance.gameObject);
    sb.Append("\n\n");
    sb.AppendFormat((string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.TOOLTIP_EXPECTATION, (object) this.GetFormattedValue(attributeInstance.GetTotalDisplayValue()));
    if ((double) instance.GetTotalDisplayValue() - (double) attributeInstance.GetTotalDisplayValue() >= 0.0)
    {
      sb.Append("\n\n");
      sb.Append((string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.TOOLTIP_EXPECTATION_OVER);
    }
    else
    {
      sb.Append("\n\n");
      sb.Append((string) DUPLICANTS.ATTRIBUTES.QUALITYOFLIFE.TOOLTIP_EXPECTATION_UNDER);
    }
    return GlobalStringBuilderPool.ReturnAndFree(sb);
  }
}

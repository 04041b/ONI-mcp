// Decompiled with JetBrains decompiler
// Type: MilkProductionDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;

#nullable disable
public class MilkProductionDisplayer(GameUtil.TimeSlice deltaTimeSlice) : AsPercentAmountDisplayer(deltaTimeSlice)
{
  public override string GetDescription(Amount master, AmountInstance instance)
  {
    Element elementByHash = ElementLoader.FindElementByHash(instance.gameObject.GetSMI<MilkProductionMonitor.Instance>().def.element);
    return $"{GameUtil.SafeStringFormat((string) CREATURES.STATS.MILKPRODUCTION.DISPLAYED_NAME, (object) elementByHash.name)}: {this.formatter.GetFormattedValue(this.ToPercent(instance.value, instance))}";
  }

  public override string GetTooltipDescription(Amount master, AmountInstance instance)
  {
    Element elementByHash = ElementLoader.FindElementByHash(instance.gameObject.GetSMI<MilkProductionMonitor.Instance>().def.element);
    return string.Format(GameUtil.SafeStringFormat(master.description, (object) elementByHash.name), (object) this.formatter.GetFormattedValue(instance.value));
  }
}

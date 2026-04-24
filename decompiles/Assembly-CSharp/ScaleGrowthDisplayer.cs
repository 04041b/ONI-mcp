// Decompiled with JetBrains decompiler
// Type: ScaleGrowthDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;

#nullable disable
public class ScaleGrowthDisplayer(GameUtil.TimeSlice deltaTimeSlice) : AsPercentAmountDisplayer(deltaTimeSlice)
{
  public override string GetDescription(Amount master, AmountInstance instance)
  {
    Tag key = instance.gameObject.PrefabID();
    return $"{(CREATURES.STATS.SCALEGROWTH.GET_DISPLAYED_NAME().ContainsKey(key) ? (object) (string) CREATURES.STATS.SCALEGROWTH.GET_DISPLAYED_NAME()[key] : (object) master.Name)}: {this.formatter.GetFormattedValue(this.ToPercent(instance.value, instance))}";
  }

  public override string GetTooltipDescription(Amount master, AmountInstance instance)
  {
    Tag key = instance.gameObject.PrefabID();
    string str = CREATURES.STATS.SCALEGROWTH.GET_TOOLTIP_PREFIX().ContainsKey(key) ? (string) CREATURES.STATS.SCALEGROWTH.GET_TOOLTIP_PREFIX()[key] : "";
    return string.Format(GameUtil.SafeStringFormat(master.description, (object) str), (object) this.formatter.GetFormattedValue(instance.value));
  }
}

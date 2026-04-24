// Decompiled with JetBrains decompiler
// Type: AllWorkTimeTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class AllWorkTimeTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    for (int idx = 0; idx < Db.Get().ChoreGroups.Count; ++idx)
      num += TrackerTool.Instance.GetWorkTimeTracker(this.WorldID, Db.Get().ChoreGroups[idx]).GetCurrentValue();
    this.AddPoint(num);
  }

  public override string FormatValueString(float value)
  {
    return GameUtil.GetFormattedPercent(value).ToString();
  }
}

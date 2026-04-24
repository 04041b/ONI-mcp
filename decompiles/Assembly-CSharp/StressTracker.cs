// Decompiled with JetBrains decompiler
// Type: StressTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public class StressTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    for (int idx = 0; idx < Components.LiveMinionIdentities.Count; ++idx)
    {
      if (Components.LiveMinionIdentities[idx].GetMyWorldId() == this.WorldID)
        num = Mathf.Max(num, Components.LiveMinionIdentities[idx].gameObject.GetAmounts().GetValue(Db.Get().Amounts.Stress.Id));
    }
    this.AddPoint(Mathf.Round(num));
  }

  public override string FormatValueString(float value) => value.ToString() + "%";
}

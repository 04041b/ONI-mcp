// Decompiled with JetBrains decompiler
// Type: ElectrobankJoulesTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class ElectrobankJoulesTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    this.AddPoint(WorldResourceAmountTracker<ElectrobankTracker>.Get().CountAmount((Dictionary<string, float>) null, ClusterManager.Instance.GetWorld(this.WorldID).worldInventory));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedJoules(value);
}

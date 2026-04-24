// Decompiled with JetBrains decompiler
// Type: RocketOxidizerTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RocketOxidizerTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    Clustercraft component = ClusterManager.Instance.GetWorld(this.WorldID).GetComponent<Clustercraft>();
    this.AddPoint((Object) component != (Object) null ? component.ModuleInterface.OxidizerPowerRemaining : 0.0f);
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedMass(value);
}

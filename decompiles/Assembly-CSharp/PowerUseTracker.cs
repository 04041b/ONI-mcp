// Decompiled with JetBrains decompiler
// Type: PowerUseTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PowerUseTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float f = 0.0f;
    foreach (ElectricalUtilityNetwork network in (IEnumerable<UtilityNetwork>) Game.Instance.electricalConduitSystem.GetNetworks())
    {
      if (network.allWires != null && network.allWires.Count != 0)
      {
        int cell = Grid.PosToCell((KMonoBehaviour) network.allWires[0]);
        if ((int) Grid.WorldIdx[cell] == this.WorldID)
          f += Game.Instance.circuitManager.GetWattsUsedByCircuit(Game.Instance.circuitManager.GetCircuitID(cell));
      }
    }
    this.AddPoint(Mathf.Round(f));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedWattage(value);
}

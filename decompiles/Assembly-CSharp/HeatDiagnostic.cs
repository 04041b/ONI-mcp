// Decompiled with JetBrains decompiler
// Type: HeatDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
public class HeatDiagnostic : ColonyDiagnostic
{
  public HeatDiagnostic(int worldID)
    : base(worldID, (string) UI.COLONY_DIAGNOSTICS.HEATDIAGNOSTIC.ALL_NAME)
  {
    this.tracker = (Tracker) TrackerTool.Instance.GetWorldTracker<BatteryTracker>(worldID);
    this.trackerSampleCountSeconds = 4f;
    this.AddCriterion("CheckHeat", new DiagnosticCriterion((string) UI.COLONY_DIAGNOSTICS.HEATDIAGNOSTIC.CRITERIA.CHECKHEAT, new Func<ColonyDiagnostic.DiagnosticResult>(this.CheckHeat)));
  }

  private ColonyDiagnostic.DiagnosticResult CheckHeat()
  {
    return new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, (string) UI.COLONY_DIAGNOSTICS.GENERIC_CRITERIA_PASS)
    {
      opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Normal,
      Message = (string) UI.COLONY_DIAGNOSTICS.BATTERYDIAGNOSTIC.NORMAL
    };
  }
}

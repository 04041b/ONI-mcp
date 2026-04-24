// Decompiled with JetBrains decompiler
// Type: ConditionNoExtraPassengers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class ConditionNoExtraPassengers : ProcessCondition
{
  private PassengerRocketModule module;

  public ConditionNoExtraPassengers(PassengerRocketModule module) => this.module = module;

  public override ProcessCondition.Status EvaluateCondition()
  {
    return !this.module.CheckExtraPassengers() ? ProcessCondition.Status.Ready : ProcessCondition.Status.Failure;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.NO_EXTRA_PASSENGERS.READY : (string) UI.STARMAP.LAUNCHCHECKLIST.NO_EXTRA_PASSENGERS.FAILURE;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.NO_EXTRA_PASSENGERS.TOOLTIP.READY : (string) UI.STARMAP.LAUNCHCHECKLIST.NO_EXTRA_PASSENGERS.TOOLTIP.FAILURE;
  }

  public override bool ShowInUI() => true;
}

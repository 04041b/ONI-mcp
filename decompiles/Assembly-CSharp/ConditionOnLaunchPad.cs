// Decompiled with JetBrains decompiler
// Type: ConditionOnLaunchPad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class ConditionOnLaunchPad : ProcessCondition
{
  private CraftModuleInterface craftInterface;

  public ConditionOnLaunchPad(CraftModuleInterface craftInterface)
  {
    this.craftInterface = craftInterface;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    return !((Object) this.craftInterface.CurrentPad != (Object) null) ? ProcessCondition.Status.Failure : ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    string statusMessage;
    switch (status)
    {
      case ProcessCondition.Status.Failure:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.STATUS.FAILURE;
        break;
      case ProcessCondition.Status.Ready:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.STATUS.READY;
        break;
      default:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.STATUS.WARNING;
        break;
    }
    return statusMessage;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    string statusTooltip;
    switch (status)
    {
      case ProcessCondition.Status.Failure:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.TOOLTIP.FAILURE;
        break;
      case ProcessCondition.Status.Ready:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.TOOLTIP.READY;
        break;
      default:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.ON_LAUNCHPAD.TOOLTIP.WARNING;
        break;
    }
    return statusTooltip;
  }

  public override bool ShowInUI() => true;
}

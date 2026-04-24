// Decompiled with JetBrains decompiler
// Type: CargoBayIsEmpty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class CargoBayIsEmpty : ProcessCondition
{
  private CommandModule commandModule;

  public CargoBayIsEmpty(CommandModule module) => this.commandModule = module;

  public override ProcessCondition.Status EvaluateCondition()
  {
    foreach (GameObject gameObject in AttachableBuilding.GetAttachedNetwork(this.commandModule.GetComponent<AttachableBuilding>()))
    {
      CargoBay component = gameObject.GetComponent<CargoBay>();
      if ((Object) component != (Object) null && (double) component.storage.MassStored() != 0.0)
        return ProcessCondition.Status.Failure;
    }
    return ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return (string) UI.STARMAP.CARGOEMPTY.NAME;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return (string) UI.STARMAP.CARGOEMPTY.TOOLTIP;
  }

  public override bool ShowInUI() => true;
}

// Decompiled with JetBrains decompiler
// Type: InternalConstructionCompleteCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class InternalConstructionCompleteCondition : ProcessCondition
{
  private BuildingInternalConstructor.Instance target;

  public InternalConstructionCompleteCondition(BuildingInternalConstructor.Instance target)
  {
    this.target = target;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    return this.target.IsRequestingConstruction() && !this.target.HasOutputInStorage() ? ProcessCondition.Status.Warning : ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.STATUS.READY : UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.STATUS.FAILURE);
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.TOOLTIP.READY : UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.TOOLTIP.FAILURE);
  }

  public override bool ShowInUI() => true;
}

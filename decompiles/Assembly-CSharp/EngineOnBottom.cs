// Decompiled with JetBrains decompiler
// Type: EngineOnBottom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class EngineOnBottom : SelectModuleCondition
{
  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    if ((Object) existingModule == (Object) null || (Object) existingModule.GetComponent<LaunchPad>() != (Object) null)
      return true;
    switch (selectionContext)
    {
      case SelectModuleCondition.SelectionContext.AddModuleBelow:
        return (Object) existingModule.GetComponent<AttachableBuilding>().GetAttachedTo() == (Object) null;
      case SelectModuleCondition.SelectionContext.ReplaceModule:
        return (Object) existingModule.GetComponent<AttachableBuilding>().GetAttachedTo() == (Object) null;
      default:
        return false;
    }
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    return ready ? (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.ENGINE_AT_BOTTOM.COMPLETE : (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.ENGINE_AT_BOTTOM.FAILED;
  }
}

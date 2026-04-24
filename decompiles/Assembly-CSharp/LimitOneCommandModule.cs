// Decompiled with JetBrains decompiler
// Type: LimitOneCommandModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class LimitOneCommandModule : SelectModuleCondition
{
  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    if ((Object) existingModule == (Object) null)
      return true;
    foreach (GameObject gameObject in AttachableBuilding.GetAttachedNetwork(existingModule.GetComponent<AttachableBuilding>()))
    {
      if ((selectionContext != SelectModuleCondition.SelectionContext.ReplaceModule || !((Object) gameObject == (Object) existingModule.gameObject)) && ((Object) gameObject.GetComponent<RocketCommandConditions>() != (Object) null || (Object) gameObject.GetComponent<BuildingUnderConstruction>() != (Object) null && (Object) gameObject.GetComponent<BuildingUnderConstruction>().Def.BuildingComplete.GetComponent<RocketCommandConditions>() != (Object) null))
        return false;
    }
    return true;
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    return ready ? (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.ONE_COMMAND_PER_ROCKET.COMPLETE : (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.ONE_COMMAND_PER_ROCKET.FAILED;
  }
}

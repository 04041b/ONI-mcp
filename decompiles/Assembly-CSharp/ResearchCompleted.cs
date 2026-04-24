// Decompiled with JetBrains decompiler
// Type: ResearchCompleted
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class ResearchCompleted : SelectModuleCondition
{
  public override bool IgnoreInSanboxMode() => true;

  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    if ((Object) existingModule == (Object) null)
      return true;
    TechItem techItem = Db.Get().TechItems.TryGet(selectedPart.PrefabID);
    return DebugHandler.InstantBuildMode || Game.Instance.SandboxModeActive || techItem == null || techItem.IsComplete();
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    return ready ? (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.RESEARCHED.COMPLETE : (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.RESEARCHED.FAILED;
  }
}

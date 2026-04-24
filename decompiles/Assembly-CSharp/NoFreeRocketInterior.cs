// Decompiled with JetBrains decompiler
// Type: NoFreeRocketInterior
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class NoFreeRocketInterior : SelectModuleCondition
{
  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    int num = 0;
    foreach (WorldContainer worldContainer in ClusterManager.Instance.WorldContainers)
    {
      if (worldContainer.IsModuleInterior)
        ++num;
    }
    return num < ClusterManager.MAX_ROCKET_INTERIOR_COUNT;
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    return ready ? (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.PASSENGER_MODULE_AVAILABLE.COMPLETE : (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.PASSENGER_MODULE_AVAILABLE.FAILED;
  }
}

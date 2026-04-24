// Decompiled with JetBrains decompiler
// Type: SelectModuleCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class SelectModuleCondition
{
  public abstract bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext);

  public abstract string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart);

  public virtual bool IgnoreInSanboxMode() => false;

  public enum SelectionContext
  {
    AddModuleAbove,
    AddModuleBelow,
    ReplaceModule,
  }
}

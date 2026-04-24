// Decompiled with JetBrains decompiler
// Type: MaterialsAvailable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class MaterialsAvailable : SelectModuleCondition
{
  public override bool IgnoreInSanboxMode() => true;

  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    return (Object) existingModule == (Object) null || ProductInfoScreen.MaterialsMet(selectedPart.CraftRecipe);
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    if (ready)
      return (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.MATERIALS_AVAILABLE.COMPLETE;
    string failed = (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.MATERIALS_AVAILABLE.FAILED;
    foreach (Recipe.Ingredient ingredient in selectedPart.CraftRecipe.Ingredients)
    {
      string str = "\n" + $"{"    • "}{ingredient.tag.ProperName()}: {GameUtil.GetFormattedMass(ingredient.amount)}";
      failed += str;
    }
    return failed;
  }
}

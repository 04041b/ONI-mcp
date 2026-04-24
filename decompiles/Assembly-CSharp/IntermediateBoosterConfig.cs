// Decompiled with JetBrains decompiler
// Type: IntermediateBoosterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class IntermediateBoosterConfig : IEntityConfig
{
  public const string ID = "IntermediateBooster";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("IntermediateBooster", (string) STRINGS.ITEMS.PILLS.INTERMEDIATEBOOSTER.NAME, (string) STRINGS.ITEMS.PILLS.INTERMEDIATEBOOSTER.DESC, 1f, true, Assets.GetAnim((HashedString) "pill_3_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, additionalTags: new List<Tag>()
    {
      GameTags.PedestalDisplayable
    });
    EntityTemplates.ExtendEntityToMedicine(looseEntity, TUNING.MEDICINE.INTERMEDIATEBOOSTER);
    ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
    {
      new ComplexRecipe.RecipeElement((Tag) SpiceNutConfig.ID, 1f)
    };
    ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
    {
      new ComplexRecipe.RecipeElement((Tag) "IntermediateBooster", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
    };
    IntermediateBoosterConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("Apothecary", (IList<ComplexRecipe.RecipeElement>) recipeElementArray1, (IList<ComplexRecipe.RecipeElement>) recipeElementArray2), recipeElementArray1, recipeElementArray2)
    {
      time = 100f,
      description = (string) STRINGS.ITEMS.PILLS.INTERMEDIATEBOOSTER.RECIPEDESC,
      nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
      fabricators = new List<Tag>() { (Tag) "Apothecary" },
      sortOrder = 5
    };
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

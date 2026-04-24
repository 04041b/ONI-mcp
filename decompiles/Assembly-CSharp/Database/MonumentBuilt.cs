// Decompiled with JetBrains decompiler
// Type: Database.MonumentBuilt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class MonumentBuilt : 
  VictoryColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override string Name()
  {
    return (string) COLONY_ACHIEVEMENTS.THRIVING.REQUIREMENTS.BUILT_MONUMENT;
  }

  public override string Description()
  {
    return (string) COLONY_ACHIEVEMENTS.THRIVING.REQUIREMENTS.BUILT_MONUMENT_DESCRIPTION;
  }

  public override bool Success()
  {
    foreach (MonumentPart monumentPart in Components.MonumentParts)
    {
      if (monumentPart.IsMonumentCompleted())
      {
        Game.Instance.unlocks.Unlock("thriving");
        return true;
      }
    }
    return false;
  }

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete) => this.Name();
}

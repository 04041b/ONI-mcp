// Decompiled with JetBrains decompiler
// Type: Database.SurviveARocketWithMinimumMorale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class SurviveARocketWithMinimumMorale : ColonyAchievementRequirement
{
  public float minimumMorale;
  public int numberOfCycles;

  public SurviveARocketWithMinimumMorale(float minimumMorale, int numberOfCycles)
  {
    this.minimumMorale = minimumMorale;
    this.numberOfCycles = numberOfCycles;
  }

  public override string GetProgress(bool complete)
  {
    return complete ? string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.SURVIVE_SPACE_COMPLETE, (object) this.minimumMorale, (object) this.numberOfCycles) : base.GetProgress(complete);
  }

  public override bool Success()
  {
    foreach (KeyValuePair<int, int> keyValuePair in SaveGame.Instance.ColonyAchievementTracker.cyclesRocketDupeMoraleAboveRequirement)
    {
      if (keyValuePair.Value >= this.numberOfCycles)
        return true;
    }
    return false;
  }
}

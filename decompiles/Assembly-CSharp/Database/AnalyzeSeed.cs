// Decompiled with JetBrains decompiler
// Type: Database.AnalyzeSeed
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class AnalyzeSeed : ColonyAchievementRequirement
{
  private string seedName;

  public AnalyzeSeed(string seedname) => this.seedName = seedname;

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.ANALYZE_SEED, (object) ((Tag) this.seedName).ProperName());
  }

  public override bool Success()
  {
    return SaveGame.Instance.ColonyAchievementTracker.analyzedSeeds.Contains((Tag) this.seedName);
  }
}

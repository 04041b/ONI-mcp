// Decompiled with JetBrains decompiler
// Type: Database.OpenTemporalTear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class OpenTemporalTear : VictoryColonyAchievementRequirement
{
  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.OPEN_TEMPORAL_TEAR;
  }

  public override string Description() => this.GetProgress(this.Success());

  public override bool Success()
  {
    return ClusterManager.Instance.GetComponent<ClusterPOIManager>().IsTemporalTearOpen();
  }

  public override string Name()
  {
    return (string) COLONY_ACHIEVEMENTS.DISTANT_PLANET_REACHED.REQUIREMENTS.OPEN_TEMPORAL_TEAR;
  }
}

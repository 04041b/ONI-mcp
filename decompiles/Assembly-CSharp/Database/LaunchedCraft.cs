// Decompiled with JetBrains decompiler
// Type: Database.LaunchedCraft
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class LaunchedCraft : ColonyAchievementRequirement
{
  public override string GetProgress(bool completed)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.LAUNCHED_ROCKET;
  }

  public override bool Success()
  {
    foreach (Clustercraft clustercraft in Components.Clustercrafts)
    {
      if (clustercraft.Status == Clustercraft.CraftStatus.InFlight)
        return true;
    }
    return false;
  }
}

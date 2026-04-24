// Decompiled with JetBrains decompiler
// Type: Database.BlockedCometWithBunkerDoor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class BlockedCometWithBunkerDoor : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override bool Success() => Game.Instance.savedInfo.blockedCometWithBunkerDoor;

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.BLOCKED_A_COMET;
  }
}

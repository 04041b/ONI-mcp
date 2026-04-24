// Decompiled with JetBrains decompiler
// Type: Database.CureDisease
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class CureDisease : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override bool Success() => Game.Instance.savedInfo.curedDisease;

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.CURED_DISEASE;
  }
}

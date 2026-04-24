// Decompiled with JetBrains decompiler
// Type: Database.HarvestAmountFromSpacePOI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class HarvestAmountFromSpacePOI : ColonyAchievementRequirement
{
  private float amountToHarvest;

  public HarvestAmountFromSpacePOI(float amountToHarvest) => this.amountToHarvest = amountToHarvest;

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.MINE_SPACE_POI, (object) SaveGame.Instance.ColonyAchievementTracker.totalMaterialsHarvestFromPOI, (object) this.amountToHarvest);
  }

  public override bool Success()
  {
    return (double) SaveGame.Instance.ColonyAchievementTracker.totalMaterialsHarvestFromPOI > (double) this.amountToHarvest;
  }
}

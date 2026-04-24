// Decompiled with JetBrains decompiler
// Type: Database.TeleportDuplicant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class TeleportDuplicant : ColonyAchievementRequirement
{
  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.TELEPORT_DUPLICANT;
  }

  public override bool Success()
  {
    foreach (WarpReceiver warpReceiver in Components.WarpReceivers.Items)
    {
      if (warpReceiver.Used)
        return true;
    }
    return false;
  }
}

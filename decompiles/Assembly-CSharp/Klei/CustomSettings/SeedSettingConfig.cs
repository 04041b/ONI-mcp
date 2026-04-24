// Decompiled with JetBrains decompiler
// Type: Klei.CustomSettings.SeedSettingConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei.CustomSettings;

public class SeedSettingConfig(
  string id,
  string label,
  string tooltip,
  bool debug_only = false,
  bool triggers_custom_game = true) : SettingConfig(id, label, tooltip, "", "", debug_only: debug_only, triggers_custom_game: triggers_custom_game)
{
  public override SettingLevel GetLevel(string level_id)
  {
    return new SettingLevel(level_id, level_id, level_id);
  }

  public override List<SettingLevel> GetLevels() => new List<SettingLevel>();
}

// Decompiled with JetBrains decompiler
// Type: ChameleonTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;

#nullable disable
public static class ChameleonTuning
{
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "ChameleonEgg".ToTag(),
      weight = 0.98f
    }
  };
  public static float STANDARD_CALORIES_PER_CYCLE = 2000000f;
  public static float STANDARD_STARVE_CYCLES = 5f;
  public static float STANDARD_STOMACH_SIZE = ChameleonTuning.STANDARD_CALORIES_PER_CYCLE * ChameleonTuning.STANDARD_STARVE_CYCLES;
  public static int PEN_SIZE_PER_CREATURE = CREATURES.SPACE_REQUIREMENTS.TIER1;
  public static float EGG_MASS = 2f;
  public const float HARVEST_COOLDOWN = 150f;
}

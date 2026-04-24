// Decompiled with JetBrains decompiler
// Type: SealTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;

#nullable disable
public static class SealTuning
{
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "SealEgg".ToTag(),
      weight = 1f
    }
  };
  public const float STANDARD_CALORIES_PER_CYCLE = 100000f;
  public const float STANDARD_STARVE_CYCLES = 10f;
  public const float STANDARD_STOMACH_SIZE = 1000000f;
  public static int PEN_SIZE_PER_CREATURE = CREATURES.SPACE_REQUIREMENTS.TIER3;
  public static float EGG_MASS = 2f;
}

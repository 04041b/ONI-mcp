// Decompiled with JetBrains decompiler
// Type: HatchTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;

#nullable disable
public static class HatchTuning
{
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchEgg".ToTag(),
      weight = 0.98f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchHardEgg".ToTag(),
      weight = 0.02f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchVeggieEgg".ToTag(),
      weight = 0.02f
    }
  };
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_HARD = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchEgg".ToTag(),
      weight = 0.32f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchHardEgg".ToTag(),
      weight = 0.65f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchMetalEgg".ToTag(),
      weight = 0.02f
    }
  };
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_VEGGIE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchEgg".ToTag(),
      weight = 0.33f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchVeggieEgg".ToTag(),
      weight = 0.67f
    }
  };
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_METAL = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchEgg".ToTag(),
      weight = 0.11f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchHardEgg".ToTag(),
      weight = 0.22f
    },
    new FertilityMonitor.BreedingChance()
    {
      egg = "HatchMetalEgg".ToTag(),
      weight = 0.67f
    }
  };
  public static float STANDARD_CALORIES_PER_CYCLE = 700000f;
  public static float STANDARD_STARVE_CYCLES = 10f;
  public static float STANDARD_STOMACH_SIZE = HatchTuning.STANDARD_CALORIES_PER_CYCLE * HatchTuning.STANDARD_STARVE_CYCLES;
  public static int PEN_SIZE_PER_CREATURE = CREATURES.SPACE_REQUIREMENTS.TIER3;
  public static float EGG_MASS = 2f;
}

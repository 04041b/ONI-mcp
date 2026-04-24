// Decompiled with JetBrains decompiler
// Type: PrehistoricPacuTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;

#nullable disable
public static class PrehistoricPacuTuning
{
  public const float LIFESPAWN = 100f;
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "PrehistoricPacuEgg".ToTag(),
      weight = 1f
    }
  };
  public const int PACUS_EATEN_PER_CYCLE = 1;
  public const float KG_PACU_MEAT_EATEN_PER_CYCLE = 1f;
  public static float STANDARD_STARVE_CYCLES = 5f;
  public static float STANDARD_CALORIES_PER_CYCLE = 100000f;
  public static float STANDARD_STOMACH_SIZE = PrehistoricPacuTuning.STANDARD_CALORIES_PER_CYCLE * PrehistoricPacuTuning.STANDARD_STARVE_CYCLES;
  public static int PEN_SIZE_PER_CREATURE = CREATURES.SPACE_REQUIREMENTS.TIER3;
  public const float POOP_MASS_KG = 60f;
  public static Tag POOP_ELEMENT = SimHashes.Rust.CreateTag();
  public static float EGG_MASS = 4f;
}

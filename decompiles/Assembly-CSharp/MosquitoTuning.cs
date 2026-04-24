// Decompiled with JetBrains decompiler
// Type: MosquitoTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public static class MosquitoTuning
{
  public const float BASE_EGG_DROP_TIME = 0.9f;
  public const float EGG_MASS = 1f;
  public static List<FertilityMonitor.BreedingChance> EGG_CHANCES_BASE = new List<FertilityMonitor.BreedingChance>()
  {
    new FertilityMonitor.BreedingChance()
    {
      egg = "MosquitoEgg".ToTag(),
      weight = 1f
    }
  };
}

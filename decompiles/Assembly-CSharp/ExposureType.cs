// Decompiled with JetBrains decompiler
// Type: ExposureType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class ExposureType
{
  public string germ_id;
  public string sickness_id;
  public string infection_effect;
  public int exposure_threshold;
  public bool infect_immediately;
  public List<string> required_traits;
  public List<string> excluded_traits;
  public List<string> excluded_effects;
  public int base_resistance;
}

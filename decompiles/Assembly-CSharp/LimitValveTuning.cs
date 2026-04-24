// Decompiled with JetBrains decompiler
// Type: LimitValveTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class LimitValveTuning
{
  public const float MAX_LIMIT = 500f;
  public const float DEFAULT_LIMIT = 100f;

  public static NonLinearSlider.Range[] GetDefaultSlider()
  {
    return new NonLinearSlider.Range[2]
    {
      new NonLinearSlider.Range(70f, 100f),
      new NonLinearSlider.Range(30f, 500f)
    };
  }
}

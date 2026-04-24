// Decompiled with JetBrains decompiler
// Type: RunningAverage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RunningAverage
{
  private RingBuffer<float> samples;
  private float min;
  private float max;
  private bool ignoreZero;

  public RunningAverage(float minValue = -3.40282347E+38f, float maxValue = 3.40282347E+38f, int sampleCount = 15, bool allowZero = true)
  {
    this.samples = new RingBuffer<float>(sampleCount, float.NaN);
    this.min = minValue;
    this.max = maxValue;
    this.ignoreZero = !allowZero;
  }

  public float AverageValue => this.GetAverage();

  public void AddSample(float value)
  {
    if ((double) value < (double) this.min || (double) value > (double) this.max || this.ignoreZero && (double) value == 0.0)
      return;
    this.samples.Add(value);
  }

  private float GetAverage()
  {
    float num1 = 0.0f;
    int num2 = 0;
    for (int offset = 0; offset < this.samples.Count; ++offset)
    {
      float sample = this.samples[offset];
      if (!float.IsNaN(sample))
      {
        num1 += sample;
        ++num2;
      }
    }
    return num2 == 0 ? float.NaN : num1 / (float) num2;
  }
}

// Decompiled with JetBrains decompiler
// Type: ElementUsage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class ElementUsage
{
  public Tag tag;
  public float amount;
  public bool continuous;
  public Func<Tag, float, bool, string> customFormating;

  public ElementUsage(Tag tag, float amount, bool continuous)
    : this(tag, amount, continuous, (Func<Tag, float, bool, string>) null)
  {
  }

  public ElementUsage(
    Tag tag,
    float amount,
    bool continuous,
    Func<Tag, float, bool, string> customFormating)
  {
    this.tag = tag;
    this.amount = amount;
    this.continuous = continuous;
    this.customFormating = customFormating;
  }
}

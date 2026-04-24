// Decompiled with JetBrains decompiler
// Type: MooSongModifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class MooSongModifier : Resource
{
  public string Description;
  public Tag TargetTag;
  public Func<string, string> TooltipCB;
  public MooSongModifier.MooSongModFn ApplyFunction;

  public MooSongModifier(
    string id,
    Tag targetTag,
    string name,
    string description,
    Func<string, string> tooltipCB,
    MooSongModifier.MooSongModFn applyFunction)
    : base(id, name)
  {
    this.Description = description;
    this.TargetTag = targetTag;
    this.TooltipCB = tooltipCB;
    this.ApplyFunction = applyFunction;
  }

  public string GetTooltip()
  {
    return this.TooltipCB != null ? this.TooltipCB(this.Description) : this.Description;
  }

  public delegate void MooSongModFn(BeckoningMonitor.Instance inst, Tag meteorTag);
}

// Decompiled with JetBrains decompiler
// Type: GermResistanceAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class GermResistanceAttributeFormatter : StandardAttributeFormatter
{
  public GermResistanceAttributeFormatter()
    : base(GameUtil.UnitClass.SimpleFloat, GameUtil.TimeSlice.None)
  {
  }

  public override string GetFormattedModifier(AttributeModifier modifier)
  {
    return GameUtil.GetGermResistanceModifierString(modifier.Value, false);
  }
}

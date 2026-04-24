// Decompiled with JetBrains decompiler
// Type: IAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;

#nullable disable
public interface IAttributeFormatter
{
  GameUtil.TimeSlice DeltaTimeSlice { get; set; }

  string GetFormattedAttribute(AttributeInstance instance);

  string GetFormattedModifier(AttributeModifier modifier);

  string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice);

  string GetTooltip(Attribute master, AttributeInstance instance);

  string GetTooltip(
    Attribute master,
    List<AttributeModifier> modifiers,
    AttributeConverters converters);
}

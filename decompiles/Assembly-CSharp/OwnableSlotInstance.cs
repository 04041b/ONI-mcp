// Decompiled with JetBrains decompiler
// Type: OwnableSlotInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
[DebuggerDisplay("{slot.Id}")]
public class OwnableSlotInstance(Assignables assignables, OwnableSlot slot) : AssignableSlotInstance(assignables, (AssignableSlot) slot)
{
}

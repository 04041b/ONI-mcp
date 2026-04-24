// Decompiled with JetBrains decompiler
// Type: CellEventInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class CellEventInstance : EventInstanceBase, ISaveLoadable
{
  [Serialize]
  public int cell;
  [Serialize]
  public int data;
  [Serialize]
  public int data2;

  public CellEventInstance(int cell, int data, int data2, CellEvent ev)
    : base((EventBase) ev)
  {
    this.cell = cell;
    this.data = data;
    this.data2 = data2;
  }
}

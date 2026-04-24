// Decompiled with JetBrains decompiler
// Type: ScheduleBlockType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;
using UnityEngine;

#nullable disable
[DebuggerDisplay("{Id}")]
public class ScheduleBlockType : Resource
{
  public Color color { get; private set; }

  public string description { get; private set; }

  public ScheduleBlockType(
    string id,
    ResourceSet parent,
    string name,
    string description,
    Color color)
    : base(id, parent, name)
  {
    this.color = color;
    this.description = description;
  }
}

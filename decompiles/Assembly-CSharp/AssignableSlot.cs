// Decompiled with JetBrains decompiler
// Type: AssignableSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[DebuggerDisplay("{Id}")]
[Serializable]
public class AssignableSlot : Resource
{
  public bool showInUI = true;

  public AssignableSlot(string id, string name, bool showInUI = true)
    : base(id, name)
  {
    this.showInUI = showInUI;
  }

  public AssignableSlotInstance Lookup(GameObject go)
  {
    Assignables component = go.GetComponent<Assignables>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null ? component.GetSlot(this) : (AssignableSlotInstance) null;
  }
}

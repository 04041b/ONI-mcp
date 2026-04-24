// Decompiled with JetBrains decompiler
// Type: Cancellable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/Cancellable")]
public class Cancellable : KMonoBehaviour
{
  private static readonly EventSystem.IntraObjectHandler<Cancellable> OnCancelDelegate = new EventSystem.IntraObjectHandler<Cancellable>((Action<Cancellable, object>) ((component, data) => component.OnCancel(data)));

  protected override void OnPrefabInit()
  {
    this.Subscribe<Cancellable>(2127324410, Cancellable.OnCancelDelegate);
  }

  protected virtual void OnCancel(object _) => this.DeleteObject();
}

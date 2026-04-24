// Decompiled with JetBrains decompiler
// Type: EventSystem2Syntax.OldExample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace EventSystem2Syntax;

internal class OldExample : KMonoBehaviour2
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe(0, new Action<object>(this.OnObjectDestroyed));
    this.Trigger(0, (object) false);
  }

  private void OnObjectDestroyed(object data) => Debug.Log((object) (bool) data);
}

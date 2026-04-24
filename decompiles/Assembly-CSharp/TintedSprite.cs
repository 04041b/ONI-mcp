// Decompiled with JetBrains decompiler
// Type: TintedSprite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[DebuggerDisplay("{name}")]
[Serializable]
public class TintedSprite : ISerializationCallbackReceiver
{
  [ReadOnly]
  public string name;
  public Sprite sprite;
  public Color color;

  public void OnAfterDeserialize()
  {
  }

  public void OnBeforeSerialize()
  {
    if (!((UnityEngine.Object) this.sprite != (UnityEngine.Object) null))
      return;
    this.name = this.sprite.name;
  }
}

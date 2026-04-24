// Decompiled with JetBrains decompiler
// Type: Refinery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/scripts/Refinery")]
public class Refinery : KMonoBehaviour
{
  protected override void OnSpawn() => base.OnSpawn();

  [Serializable]
  public struct OrderSaveData(string id, bool infinite)
  {
    public string id = id;
    public bool infinite = infinite;
  }
}

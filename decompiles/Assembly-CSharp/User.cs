// Decompiled with JetBrains decompiler
// Type: User
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/User")]
public class User : KMonoBehaviour
{
  public void OnStateMachineStop(string reason, StateMachine.Status status)
  {
    if (status == StateMachine.Status.Success)
      this.Trigger(58624316, (object) null);
    else
      this.Trigger(1572098533, (object) null);
  }
}

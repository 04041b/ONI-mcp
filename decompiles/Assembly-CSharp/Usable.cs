// Decompiled with JetBrains decompiler
// Type: Usable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public abstract class Usable : KMonoBehaviour, IStateMachineTarget
{
  private StateMachine.Instance smi;

  public abstract void StartUsing(User user);

  protected void StartUsing(StateMachine.Instance smi, User user)
  {
    DebugUtil.Assert(this.smi == null);
    DebugUtil.Assert(smi != null);
    this.smi = smi;
    smi.OnStop += new Action<string, StateMachine.Status>(user.OnStateMachineStop);
    smi.StartSM();
  }

  public void StopUsing(User user)
  {
    if (this.smi == null)
      return;
    this.smi.OnStop -= new Action<string, StateMachine.Status>(user.OnStateMachineStop);
    this.smi.StopSM("Usable.StopUsing");
    this.smi = (StateMachine.Instance) null;
  }
}

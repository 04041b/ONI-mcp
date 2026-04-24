// Decompiled with JetBrains decompiler
// Type: MingleMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class MingleMonitor : GameStateMachine<MingleMonitor, MingleMonitor.Instance>
{
  public GameStateMachine<MingleMonitor, MingleMonitor.Instance, IStateMachineTarget, object>.State mingle;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.mingle;
    this.serializable = StateMachine.SerializeType.Never;
    this.mingle.ToggleRecurringChore(new Func<MingleMonitor.Instance, Chore>(this.CreateMingleChore));
  }

  private Chore CreateMingleChore(MingleMonitor.Instance smi)
  {
    return (Chore) new MingleChore(smi.master);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<MingleMonitor, MingleMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
  }
}

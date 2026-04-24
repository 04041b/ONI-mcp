// Decompiled with JetBrains decompiler
// Type: IdleMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class IdleMonitor : GameStateMachine<IdleMonitor, IdleMonitor.Instance>
{
  public GameStateMachine<IdleMonitor, IdleMonitor.Instance, IStateMachineTarget, object>.State idle;
  public GameStateMachine<IdleMonitor, IdleMonitor.Instance, IStateMachineTarget, object>.State stopped;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.idle;
    this.idle.TagTransition(GameTags.Dying, this.stopped).ToggleRecurringChore(new Func<IdleMonitor.Instance, Chore>(this.CreateIdleChore));
    this.stopped.DoNothing();
  }

  private Chore CreateIdleChore(IdleMonitor.Instance smi) => (Chore) new IdleChore(smi.master);

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<IdleMonitor, IdleMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
  }
}

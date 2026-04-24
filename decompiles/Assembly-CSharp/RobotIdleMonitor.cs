// Decompiled with JetBrains decompiler
// Type: RobotIdleMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RobotIdleMonitor : GameStateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance>
{
  public GameStateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance, IStateMachineTarget, object>.State idle;
  public GameStateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance, IStateMachineTarget, object>.State working;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.idle;
    this.idle.PlayAnim("idle_loop", KAnim.PlayMode.Loop).Transition(this.working, (StateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !RobotIdleMonitor.CheckShouldIdle(smi)));
    this.working.Transition(this.idle, (StateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => RobotIdleMonitor.CheckShouldIdle(smi)));
  }

  private static bool CheckShouldIdle(RobotIdleMonitor.Instance smi)
  {
    FallMonitor.Instance smi1 = smi.master.gameObject.GetSMI<FallMonitor.Instance>();
    if (smi1 == null)
      return true;
    return !smi.master.gameObject.GetComponent<ChoreConsumer>().choreDriver.HasChore() && smi1.GetCurrentState() == smi1.sm.standing;
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget master, RobotIdleMonitor.Def def) : 
    GameStateMachine<RobotIdleMonitor, RobotIdleMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public KBatchedAnimController eyes;
  }
}

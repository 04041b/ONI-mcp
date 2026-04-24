// Decompiled with JetBrains decompiler
// Type: InSpaceMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public class InSpaceMonitor : GameStateMachine<InSpaceMonitor, InSpaceMonitor.Instance>
{
  private const string SPACE_EFFECT_NAME = "SpaceBuzz";
  public GameStateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.State idle;
  public GameStateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.State inSpace;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.idle;
    this.root.Enter((StateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi =>
    {
      if (!smi.IsInSpace())
        return;
      smi.GoTo((StateMachine.BaseState) this.inSpace);
    }));
    this.idle.Transition(this.inSpace, (StateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsInSpace()), UpdateRate.SIM_1000ms).Enter((StateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi =>
    {
      Effects component = smi.master.gameObject.GetComponent<Effects>();
      if (!((Object) component != (Object) null) || !component.HasEffect("SpaceBuzz"))
        return;
      component.Remove("SpaceBuzz");
    }));
    this.inSpace.Transition(this.idle, (StateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsInSpace()), UpdateRate.SIM_1000ms).ToggleEffect("SpaceBuzz");
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<InSpaceMonitor, InSpaceMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public bool IsInSpace()
    {
      WorldContainer myWorld = this.GetMyWorld();
      if (!(bool) (Object) myWorld)
        return false;
      int parentWorldId = myWorld.ParentWorldId;
      int id = myWorld.id;
      return (bool) (Object) myWorld.GetComponent<Clustercraft>() && parentWorldId == id;
    }
  }
}

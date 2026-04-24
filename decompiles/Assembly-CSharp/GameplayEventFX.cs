// Decompiled with JetBrains decompiler
// Type: GameplayEventFX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GameplayEventFX : GameStateMachine<GameplayEventFX, GameplayEventFX.Instance>
{
  public StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.TargetParameter fx;
  public StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.IntParameter notificationCount;
  public GameStateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.State single;
  public GameStateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.State multiple;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.Target(this.fx);
    this.root.PlayAnim("event_pre").OnAnimQueueComplete(this.single).Exit("DestroyFX", (StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.State.Callback) (smi => smi.DestroyFX()));
    this.single.PlayAnim("event_loop", KAnim.PlayMode.Loop).ParamTransition<int>((StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.Parameter<int>) this.notificationCount, this.multiple, (StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.Parameter<int>.Callback) ((smi, p) => p > 1));
    this.multiple.PlayAnim("event_loop_multiple", KAnim.PlayMode.Loop).ParamTransition<int>((StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.Parameter<int>) this.notificationCount, this.single, (StateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.Parameter<int>.Callback) ((smi, p) => p == 1));
  }

  public new class Instance : 
    GameStateMachine<GameplayEventFX, GameplayEventFX.Instance, IStateMachineTarget, object>.GameInstance
  {
    public int previousCount;

    public Instance(IStateMachineTarget master, Vector3 offset)
      : base(master)
    {
      this.sm.fx.Set(FXHelpers.CreateEffect("event_alert_fx_kanim", this.smi.master.transform.GetPosition() + offset, this.smi.master.transform).gameObject, this.smi, false);
    }

    public void DestroyFX() => Util.KDestroyGameObject(this.sm.fx.Get(this.smi));
  }
}

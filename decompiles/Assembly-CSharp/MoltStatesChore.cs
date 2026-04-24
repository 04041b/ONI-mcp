// Decompiled with JetBrains decompiler
// Type: MoltStatesChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class MoltStatesChore : 
  GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>
{
  public GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.State molting;
  public GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.State complete;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.molting;
    this.molting.PlayAnim((Func<MoltStatesChore.Instance, string>) (smi => smi.def.moltAnimName)).ScheduleGoTo(5f, (StateMachine.BaseState) this.complete).OnAnimQueueComplete(this.complete);
    this.complete.BehaviourComplete(GameTags.Creatures.ReadyToMolt);
  }

  public class Def : StateMachine.BaseDef
  {
    public string moltAnimName;
  }

  public new class Instance : 
    GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.GameInstance
  {
    public Instance(Chore<MoltStatesChore.Instance> chore, MoltStatesChore.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.AddPrecondition(ChorePreconditions.instance.CheckBehaviourPrecondition, (object) GameTags.Creatures.ReadyToMolt);
    }
  }
}

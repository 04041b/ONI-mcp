// Decompiled with JetBrains decompiler
// Type: HiveHarvestStates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class HiveHarvestStates : 
  GameStateMachine<HiveHarvestStates, HiveHarvestStates.Instance, IStateMachineTarget, HiveHarvestStates.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.DoNothing();
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance : 
    GameStateMachine<HiveHarvestStates, HiveHarvestStates.Instance, IStateMachineTarget, HiveHarvestStates.Def>.GameInstance
  {
    public Instance(Chore<HiveHarvestStates.Instance> chore, HiveHarvestStates.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.AddPrecondition(ChorePreconditions.instance.CheckBehaviourPrecondition, (object) GameTags.Creatures.Behaviours.HarvestHiveBehaviour);
    }
  }
}

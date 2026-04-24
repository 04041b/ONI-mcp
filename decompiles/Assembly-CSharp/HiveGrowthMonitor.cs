// Decompiled with JetBrains decompiler
// Type: HiveGrowthMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class HiveGrowthMonitor : 
  GameStateMachine<HiveGrowthMonitor, HiveGrowthMonitor.Instance, IStateMachineTarget, HiveGrowthMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.Creatures.Behaviours.GrowUpBehaviour, new StateMachine<HiveGrowthMonitor, HiveGrowthMonitor.Instance, IStateMachineTarget, HiveGrowthMonitor.Def>.Transition.ConditionCallback(HiveGrowthMonitor.IsGrowing));
  }

  public static bool IsGrowing(HiveGrowthMonitor.Instance smi)
  {
    return !smi.GetSMI<BeeHive.StatesInstance>().IsFullyGrown();
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget master, HiveGrowthMonitor.Def def) : 
    GameStateMachine<HiveGrowthMonitor, HiveGrowthMonitor.Instance, IStateMachineTarget, HiveGrowthMonitor.Def>.GameInstance(master, def)
  {
  }
}

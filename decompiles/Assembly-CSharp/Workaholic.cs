// Decompiled with JetBrains decompiler
// Type: Workaholic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[SkipSaveFileSerialization]
public class Workaholic : StateMachineComponent<Workaholic.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  protected bool IsUncomfortable()
  {
    return this.smi.master.GetComponent<ChoreDriver>().GetCurrentChore() is IdleChore;
  }

  public class StatesInstance(Workaholic master) : 
    GameStateMachine<Workaholic.States, Workaholic.StatesInstance, Workaholic, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<Workaholic.States, Workaholic.StatesInstance, Workaholic>
  {
    public GameStateMachine<Workaholic.States, Workaholic.StatesInstance, Workaholic, object>.State satisfied;
    public GameStateMachine<Workaholic.States, Workaholic.StatesInstance, Workaholic, object>.State suffering;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.satisfied;
      this.root.Update("WorkaholicCheck", (Action<Workaholic.StatesInstance, float>) ((smi, dt) =>
      {
        if (smi.master.IsUncomfortable())
          smi.GoTo((StateMachine.BaseState) this.suffering);
        else
          smi.GoTo((StateMachine.BaseState) this.satisfied);
      }), UpdateRate.SIM_1000ms);
      this.suffering.AddEffect("Restless").ToggleExpression(Db.Get().Expressions.Uncomfortable);
      this.satisfied.DoNothing();
    }
  }
}

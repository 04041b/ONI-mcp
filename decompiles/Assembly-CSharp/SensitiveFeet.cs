// Decompiled with JetBrains decompiler
// Type: SensitiveFeet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[SkipSaveFileSerialization]
public class SensitiveFeet : StateMachineComponent<SensitiveFeet.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  protected bool IsUncomfortable()
  {
    int num = Grid.CellBelow(Grid.PosToCell(this.gameObject));
    return Grid.IsValidCell(num) && Grid.Solid[num] && (UnityEngine.Object) Grid.Objects[num, 9] == (UnityEngine.Object) null;
  }

  public class StatesInstance(SensitiveFeet master) : 
    GameStateMachine<SensitiveFeet.States, SensitiveFeet.StatesInstance, SensitiveFeet, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<SensitiveFeet.States, SensitiveFeet.StatesInstance, SensitiveFeet>
  {
    public GameStateMachine<SensitiveFeet.States, SensitiveFeet.StatesInstance, SensitiveFeet, object>.State satisfied;
    public GameStateMachine<SensitiveFeet.States, SensitiveFeet.StatesInstance, SensitiveFeet, object>.State suffering;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.satisfied;
      this.root.Update("SensitiveFeetCheck", (Action<SensitiveFeet.StatesInstance, float>) ((smi, dt) =>
      {
        if (smi.master.IsUncomfortable())
          smi.GoTo((StateMachine.BaseState) this.suffering);
        else
          smi.GoTo((StateMachine.BaseState) this.satisfied);
      }), UpdateRate.SIM_1000ms);
      this.suffering.AddEffect("UncomfortableFeet").ToggleExpression(Db.Get().Expressions.Uncomfortable);
      this.satisfied.DoNothing();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Thriver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
[SkipSaveFileSerialization]
public class Thriver : StateMachineComponent<Thriver.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  public class StatesInstance(Thriver master) : 
    GameStateMachine<Thriver.States, Thriver.StatesInstance, Thriver, object>.GameInstance(master)
  {
    public bool IsStressed()
    {
      StressMonitor.Instance smi = this.master.GetSMI<StressMonitor.Instance>();
      return smi != null && smi.IsStressed();
    }
  }

  public class States : GameStateMachine<Thriver.States, Thriver.StatesInstance, Thriver>
  {
    public GameStateMachine<Thriver.States, Thriver.StatesInstance, Thriver, object>.State idle;
    public GameStateMachine<Thriver.States, Thriver.StatesInstance, Thriver, object>.State stressed;
    public GameStateMachine<Thriver.States, Thriver.StatesInstance, Thriver, object>.State toostressed;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.idle;
      this.root.EventTransition(GameHashes.NotStressed, this.idle).EventTransition(GameHashes.Stressed, this.stressed).EventTransition(GameHashes.StressedHadEnough, this.stressed).Enter((StateMachine<Thriver.States, Thriver.StatesInstance, Thriver, object>.State.Callback) (smi =>
      {
        StressMonitor.Instance smi1 = smi.master.GetSMI<StressMonitor.Instance>();
        if (smi1 == null || !smi1.IsStressed())
          return;
        smi.GoTo((StateMachine.BaseState) this.stressed);
      }));
      this.idle.DoNothing();
      this.stressed.ToggleEffect(nameof (Thriver));
      this.toostressed.DoNothing();
    }
  }
}

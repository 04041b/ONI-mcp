// Decompiled with JetBrains decompiler
// Type: DoctorMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class DoctorMonitor : GameStateMachine<DoctorMonitor, DoctorMonitor.Instance>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
    this.root.ToggleUrge(Db.Get().Urges.Doctor);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<DoctorMonitor, DoctorMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
  }
}

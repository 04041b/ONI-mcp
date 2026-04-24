// Decompiled with JetBrains decompiler
// Type: FlowerVase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FlowerVase : StateMachineComponent<FlowerVase.SMInstance>
{
  [MyCmpReq]
  private PlantablePlot plantablePlot;
  [MyCmpReq]
  private KBoxCollider2D boxCollider;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi.StartSM();
  }

  public class SMInstance(FlowerVase master) : 
    GameStateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase>
  {
    public GameStateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase, object>.State empty;
    public GameStateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase, object>.State full;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.empty;
      this.empty.EventTransition(GameHashes.OccupantChanged, this.full, (StateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase, object>.Transition.ConditionCallback) (smi => (Object) smi.master.plantablePlot.Occupant != (Object) null)).PlayAnim("off");
      this.full.EventTransition(GameHashes.OccupantChanged, this.empty, (StateMachine<FlowerVase.States, FlowerVase.SMInstance, FlowerVase, object>.Transition.ConditionCallback) (smi => (Object) smi.master.plantablePlot.Occupant == (Object) null)).PlayAnim("on");
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: FishOvercrowdingMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FishOvercrowdingMonitor : 
  GameStateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>
{
  private readonly GameStateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>.State satisfied;
  private readonly GameStateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>.State overcrowded;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.satisfied;
    this.root.Enter(new StateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>.State.Callback(FishOvercrowdingMonitor.Register)).Exit(new StateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>.State.Callback(FishOvercrowdingMonitor.Unregister));
    this.satisfied.DoNothing();
    this.overcrowded.DoNothing();
  }

  private static void Register(FishOvercrowdingMonitor.Instance smi)
  {
    FishOvercrowingManager instance = FishOvercrowingManager.Instance;
    if ((Object) instance == (Object) null)
      return;
    instance.Add(smi.PrefabID);
  }

  private static void Unregister(FishOvercrowdingMonitor.Instance smi)
  {
    FishOvercrowingManager instance = FishOvercrowingManager.Instance;
    if ((Object) instance == (Object) null)
      return;
    instance.Remove(smi.PrefabID);
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget master, FishOvercrowdingMonitor.Def def) : 
    GameStateMachine<FishOvercrowdingMonitor, FishOvercrowdingMonitor.Instance, IStateMachineTarget, FishOvercrowdingMonitor.Def>.GameInstance(master, def)
  {
    [MyCmpReq]
    private readonly KPrefabID prefabID;

    public KPrefabID PrefabID => this.prefabID;
  }
}

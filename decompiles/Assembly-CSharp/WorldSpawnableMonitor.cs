// Decompiled with JetBrains decompiler
// Type: WorldSpawnableMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class WorldSpawnableMonitor : 
  GameStateMachine<WorldSpawnableMonitor, WorldSpawnableMonitor.Instance, IStateMachineTarget, WorldSpawnableMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
  }

  public class Def : StateMachine.BaseDef
  {
    public Func<int, int> adjustSpawnLocationCb;
  }

  public new class Instance(IStateMachineTarget master, WorldSpawnableMonitor.Def def) : 
    GameStateMachine<WorldSpawnableMonitor, WorldSpawnableMonitor.Instance, IStateMachineTarget, WorldSpawnableMonitor.Def>.GameInstance(master, def)
  {
  }
}

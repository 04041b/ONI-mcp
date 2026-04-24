// Decompiled with JetBrains decompiler
// Type: GameStateMachine`3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType> : 
  GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>
  where StateMachineType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>
  where StateMachineInstanceType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>.GameInstance
  where MasterType : IStateMachineTarget
{
}

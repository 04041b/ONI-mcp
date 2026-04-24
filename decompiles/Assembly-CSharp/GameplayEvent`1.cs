// Decompiled with JetBrains decompiler
// Type: GameplayEvent`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class GameplayEvent<StateMachineInstanceType> : GameplayEvent where StateMachineInstanceType : StateMachine.Instance
{
  public GameplayEvent(
    string id,
    int priority = 0,
    int importance = 0,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
    : base(id, priority, importance, requiredDlcIds, forbiddenDlcIds)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: RoomMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RoomMonitor : GameStateMachine<RoomMonitor, RoomMonitor.Instance>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.EventHandler(GameHashes.PathAdvanced, new StateMachine<RoomMonitor, RoomMonitor.Instance, IStateMachineTarget, object>.State.Callback(RoomMonitor.UpdateRoomType));
  }

  private static void UpdateRoomType(RoomMonitor.Instance smi)
  {
    Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(smi.master.gameObject);
    if (roomOfGameObject == smi.currentRoom)
      return;
    smi.currentRoom = roomOfGameObject;
    roomOfGameObject?.cavity.OnEnter((object) smi.master.gameObject);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<RoomMonitor, RoomMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public Room currentRoom;
  }
}

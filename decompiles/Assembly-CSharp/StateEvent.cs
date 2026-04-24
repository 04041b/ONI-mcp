// Decompiled with JetBrains decompiler
// Type: StateEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class StateEvent
{
  protected string name;
  private string debugName;

  public StateEvent(string name)
  {
    this.name = name;
    this.debugName = "(Event)" + name;
  }

  public virtual StateEvent.Context Subscribe(StateMachine.Instance smi)
  {
    return new StateEvent.Context(this);
  }

  public virtual void Unsubscribe(StateMachine.Instance smi, StateEvent.Context context)
  {
  }

  public string GetName() => this.name;

  public string GetDebugName() => this.debugName;

  public struct Context(StateEvent state_event)
  {
    public StateEvent stateEvent = state_event;
    public int data = 0;
  }
}

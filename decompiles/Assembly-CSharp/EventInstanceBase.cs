// Decompiled with JetBrains decompiler
// Type: EventInstanceBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class EventInstanceBase : ISaveLoadable
{
  [Serialize]
  public int frame;
  [Serialize]
  public int eventHash;
  public EventBase ev;

  public EventInstanceBase(EventBase ev)
  {
    this.frame = GameClock.Instance.GetFrame();
    this.eventHash = ev.hash;
    this.ev = ev;
  }

  public override string ToString()
  {
    string str = $"[{this.frame.ToString()}] ";
    return this.ev != null ? str + this.ev.GetDescription(this) : str + "Unknown event";
  }
}

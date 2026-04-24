// Decompiled with JetBrains decompiler
// Type: CellElementEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
public class CellElementEvent(string id, string reason, bool is_send, bool enable_logging = true) : 
  CellEvent(id, reason, is_send, enable_logging)
{
  [Conditional("ENABLE_CELL_EVENT_LOGGER")]
  public void Log(int cell, SimHashes element, int callback_id)
  {
    if (!this.enableLogging)
      return;
    CellEventInstance ev = new CellEventInstance(cell, (int) element, 0, (CellEvent) this);
    CellEventLogger.Instance.Add(ev);
  }

  public override string GetDescription(EventInstanceBase ev)
  {
    SimHashes data = (SimHashes) (ev as CellEventInstance).data;
    return $"{this.GetMessagePrefix()}Element={data.ToString()} ({this.reason})";
  }
}

// Decompiled with JetBrains decompiler
// Type: DebugOverlays
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class DebugOverlays : KScreen
{
  public static DebugOverlays instance { get; private set; }

  protected override void OnPrefabInit()
  {
    DebugOverlays.instance = this;
    KPopupMenu componentInChildren = this.GetComponentInChildren<KPopupMenu>();
    componentInChildren.SetOptions((IList<string>) new string[5]
    {
      "None",
      "Rooms",
      "Lighting",
      "Style",
      "Flow"
    });
    componentInChildren.OnSelect += new Action<string, int>(this.OnSelect);
    this.gameObject.SetActive(false);
  }

  private void OnSelect(string str, int index)
  {
    switch (str)
    {
      case "None":
        SimDebugView.Instance.SetMode(OverlayModes.None.ID);
        break;
      case "Flow":
        SimDebugView.Instance.SetMode(SimDebugView.OverlayModes.Flow);
        break;
      case "Lighting":
        SimDebugView.Instance.SetMode(OverlayModes.Light.ID);
        break;
      case "Rooms":
        SimDebugView.Instance.SetMode(OverlayModes.Rooms.ID);
        break;
      default:
        Debug.LogError((object) ("Unknown debug view: " + str));
        break;
    }
  }
}

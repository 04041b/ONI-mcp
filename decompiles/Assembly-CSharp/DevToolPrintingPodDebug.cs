// Decompiled with JetBrains decompiler
// Type: DevToolPrintingPodDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using UnityEngine;

#nullable disable
public class DevToolPrintingPodDebug : DevTool
{
  protected override void RenderTo(DevPanel panel)
  {
    if ((Object) Immigration.Instance != (Object) null)
      this.ShowButtons();
    else
      ImGui.Text("Game not available");
  }

  private void ShowButtons()
  {
    if (Components.Telepads.Count == 0)
    {
      ImGui.Text("No printing pods available");
    }
    else
    {
      ImGui.Text($"Time until next print available: {Mathf.CeilToInt(Immigration.Instance.timeBeforeSpawn).ToString()}s");
      if (ImGui.Button("Activate now"))
        Immigration.Instance.timeBeforeSpawn = 0.0f;
      if (!ImGui.Button("Shuffle Options"))
        return;
      if ((Object) ImmigrantScreen.instance.Telepad == (Object) null)
        ImmigrantScreen.InitializeImmigrantScreen(Components.Telepads[0]);
      else
        ImmigrantScreen.instance.DebugShuffleOptions();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: DevToolWarning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using STRINGS;
using UnityEngine;

#nullable disable
public class DevToolWarning
{
  private bool showAgain;
  public string Name;
  public bool ShouldDrawWindow;

  public DevToolWarning() => this.Name = (string) UI.FRONTEND.DEVTOOLS.TITLE;

  public void DrawMenuBar()
  {
    if (!ImGui.BeginMainMenuBar())
      return;
    ImGui.Checkbox(this.Name, ref this.ShouldDrawWindow);
    ImGui.EndMainMenuBar();
  }

  public void DrawWindow(out bool isOpen)
  {
    ImGuiWindowFlags flags = ImGuiWindowFlags.None;
    isOpen = true;
    if (!ImGui.Begin(this.Name + "###ID_DevToolWarning", ref isOpen, flags))
      return;
    if (!isOpen)
    {
      ImGui.End();
    }
    else
    {
      ImGui.SetWindowSize(new Vector2(500f, 250f));
      ImGui.TextWrapped((string) UI.FRONTEND.DEVTOOLS.WARNING);
      ImGui.Spacing();
      ImGui.Spacing();
      ImGui.Spacing();
      ImGui.Spacing();
      ImGui.Checkbox((string) UI.FRONTEND.DEVTOOLS.DONTSHOW, ref this.showAgain);
      if (ImGui.Button((string) UI.FRONTEND.DEVTOOLS.BUTTON))
      {
        if (this.showAgain)
          KPlayerPrefs.SetInt("ShowDevtools", 1);
        DevToolManager.Instance.UserAcceptedWarning = true;
        isOpen = false;
      }
      ImGui.End();
    }
  }
}

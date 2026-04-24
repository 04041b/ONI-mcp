// Decompiled with JetBrains decompiler
// Type: DevToolEntity_SearchGameObjects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System;

#nullable disable
public class DevToolEntity_SearchGameObjects : DevTool
{
  private Action<DevToolEntityTarget> onSelectionMadeFn;

  public DevToolEntity_SearchGameObjects(Action<DevToolEntityTarget> onSelectionMadeFn)
  {
    this.onSelectionMadeFn = onSelectionMadeFn;
  }

  protected override void RenderTo(DevPanel panel) => ImGui.Text("Not implemented yet");
}

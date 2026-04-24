// Decompiled with JetBrains decompiler
// Type: DevToolPOITechUnlocks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using UnityEngine;

#nullable disable
public class DevToolPOITechUnlocks : DevTool
{
  protected override void RenderTo(DevPanel panel)
  {
    if ((Object) Research.Instance == (Object) null)
      return;
    foreach (TechItem resource in Db.Get().TechItems.resources)
    {
      if (resource.isPOIUnlock)
      {
        ImGui.Text(resource.Id);
        ImGui.SameLine();
        bool v = resource.IsComplete();
        if (ImGui.Checkbox("Unlocked ", ref v))
          resource.POIUnlocked();
      }
    }
  }
}

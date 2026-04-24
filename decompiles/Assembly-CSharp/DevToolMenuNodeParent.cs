// Decompiled with JetBrains decompiler
// Type: DevToolMenuNodeParent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System.Collections.Generic;

#nullable disable
public class DevToolMenuNodeParent : IMenuNode
{
  public string name;
  public List<IMenuNode> children;

  public DevToolMenuNodeParent(string name)
  {
    this.name = name;
    this.children = new List<IMenuNode>();
  }

  public void AddChild(IMenuNode menuNode) => this.children.Add(menuNode);

  public string GetName() => this.name;

  public void Draw()
  {
    if (!ImGui.BeginMenu(this.name))
      return;
    foreach (IMenuNode child in this.children)
      child.Draw();
    ImGui.EndMenu();
  }
}

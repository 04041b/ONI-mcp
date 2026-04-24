// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.UnityObjectDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using UnityEngine;

#nullable disable
namespace ImGuiObjectDrawer;

public class UnityObjectDrawer : PlainCSharpObjectDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is Object;
  }

  protected override void DrawCustom(
    in MemberDrawContext context,
    in MemberDetails member,
    int depth)
  {
    Object @object = (Object) member.value;
    ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
    if (context.default_open && depth <= 0)
      flags |= ImGuiTreeNodeFlags.DefaultOpen;
    int num = ImGui.TreeNodeEx(member.name, flags) ? 1 : 0;
    DrawerUtil.Tooltip(member.type);
    if (num == 0)
      return;
    this.DrawContents(in context, in member, depth);
    ImGui.TreePop();
  }
}

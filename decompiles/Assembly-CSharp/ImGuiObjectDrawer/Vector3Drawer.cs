// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.Vector3Drawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class Vector3Drawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is Vector3;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    Vector3 vector3 = (Vector3) member.value;
    ImGuiEx.SimpleField(member.name, $"( {vector3.x}, {vector3.y}, {vector3.z} )");
  }
}

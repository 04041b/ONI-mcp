// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.NullDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ImGuiObjectDrawer;

public class NullDrawer : InlineDrawer
{
  public override bool CanDrawAtDepth(int depth) => true;

  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value == null;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    ImGuiEx.SimpleField(member.name, "null");
  }
}

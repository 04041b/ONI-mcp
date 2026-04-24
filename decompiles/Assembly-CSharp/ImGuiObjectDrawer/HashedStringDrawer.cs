// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.HashedStringDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class HashedStringDrawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is HashedString;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    HashedString hashedString = (HashedString) member.value;
    string str1 = hashedString.ToString();
    string str2 = "0x" + hashedString.HashValue.ToString("X");
    ImGuiEx.SimpleField(member.name, $"{str1} ({str2})");
  }
}

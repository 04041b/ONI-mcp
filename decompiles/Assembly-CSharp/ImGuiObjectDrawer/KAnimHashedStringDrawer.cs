// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.KAnimHashedStringDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class KAnimHashedStringDrawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is KAnimHashedString;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    KAnimHashedString kanimHashedString = (KAnimHashedString) member.value;
    string str1 = kanimHashedString.ToString();
    string str2 = "0x" + kanimHashedString.HashValue.ToString("X");
    ImGuiEx.SimpleField(member.name, $"{str1} ({str2})");
  }
}

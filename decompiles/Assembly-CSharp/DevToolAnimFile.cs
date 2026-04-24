// Decompiled with JetBrains decompiler
// Type: DevToolAnimFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class DevToolAnimFile : DevTool
{
  private KAnimFile animFile;

  public DevToolAnimFile(KAnimFile animFile)
  {
    this.animFile = animFile;
    this.Name = $"Anim File: \"{animFile.name}\"";
  }

  protected override void RenderTo(DevPanel panel)
  {
    ImGuiEx.DrawObject((object) this.animFile);
    ImGuiEx.DrawObject((object) this.animFile.GetData());
  }
}

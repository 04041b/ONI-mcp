// Decompiled with JetBrains decompiler
// Type: DevToolObjectViewer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DevToolObjectViewer<T> : DevTool
{
  private Func<T> getValue;

  public DevToolObjectViewer(Func<T> getValue)
  {
    this.getValue = getValue;
    this.Name = typeof (T).Name;
  }

  protected override void RenderTo(DevPanel panel)
  {
    T obj = this.getValue();
    this.Name = obj.GetType().Name;
    ImGuiEx.DrawObject((object) obj);
  }
}

// Decompiled with JetBrains decompiler
// Type: DevToolMenuNodeAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DevToolMenuNodeAction : IMenuNode
{
  public string name;
  public System.Action onClickFn;
  public Func<bool> isEnabledFn;

  public DevToolMenuNodeAction(string name, System.Action onClickFn)
  {
    this.name = name;
    this.onClickFn = onClickFn;
  }

  public string GetName() => this.name;

  public void Draw()
  {
    if (!ImGuiEx.MenuItem(this.name, this.isEnabledFn == null || this.isEnabledFn()))
      return;
    this.onClickFn();
  }
}

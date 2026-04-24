// Decompiled with JetBrains decompiler
// Type: DebugElementMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DebugElementMenu : KButtonMenu
{
  public static DebugElementMenu Instance;
  public GameObject root;

  protected override void OnPrefabInit()
  {
    DebugElementMenu.Instance = this;
    base.OnPrefabInit();
    this.ConsumeMouseScroll = true;
  }

  protected override void OnForcedCleanUp()
  {
    DebugElementMenu.Instance = (DebugElementMenu) null;
    base.OnForcedCleanUp();
  }

  public void Turnoff() => this.root.gameObject.SetActive(false);
}

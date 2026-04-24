// Decompiled with JetBrains decompiler
// Type: ClippyPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ClippyPanel : KScreen
{
  public Text title;
  public Text detailText;
  public Text flavorText;
  public Image topicIcon;
  private KButton okButton;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnActivate()
  {
    base.OnActivate();
    SpeedControlScreen.Instance.Pause();
    Game.Instance.Trigger(1634669191, (object) null);
  }

  public void OnOk()
  {
    SpeedControlScreen.Instance.Unpause();
    Object.Destroy((Object) this.gameObject);
  }
}

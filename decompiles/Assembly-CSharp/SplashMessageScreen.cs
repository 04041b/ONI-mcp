// Decompiled with JetBrains decompiler
// Type: SplashMessageScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SplashMessageScreen")]
public class SplashMessageScreen : KMonoBehaviour
{
  public KButton forumButton;
  public KButton confirmButton;
  public LocText bodyText;
  public bool previewInEditor;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.forumButton.onClick += (System.Action) (() => App.OpenWebURL("https://forums.kleientertainment.com/forums/forum/118-oxygen-not-included/"));
    this.confirmButton.onClick += (System.Action) (() =>
    {
      this.gameObject.SetActive(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
    });
    this.bodyText.text = (string) STRINGS.UI.DEVELOPMENTBUILDS.ALPHA.LOADING.BODY;
  }

  private void OnEnable()
  {
    this.confirmButton.GetComponent<LayoutElement>();
    this.confirmButton.GetComponentInChildren<LocText>();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (!DlcManager.IsExpansion1Active())
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    else
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
  }
}

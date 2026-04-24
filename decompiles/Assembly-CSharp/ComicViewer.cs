// Decompiled with JetBrains decompiler
// Type: ComicViewer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ComicViewer : KScreen
{
  public GameObject panelPrefab;
  public GameObject contentContainer;
  public List<GameObject> activePanels = new List<GameObject>();
  public KButton closeButton;
  public System.Action OnStop;

  public void ShowComic(ComicData comic, bool isVictoryComic)
  {
    for (int index = 0; index < Mathf.Max(comic.images.Length, comic.stringKeys.Length); ++index)
    {
      GameObject gameObject = Util.KInstantiateUI(this.panelPrefab, this.contentContainer, true);
      this.activePanels.Add(gameObject);
      gameObject.GetComponentInChildren<Image>().sprite = comic.images[index];
      gameObject.GetComponentInChildren<LocText>().SetText(comic.stringKeys[index]);
    }
    this.closeButton.ClearOnClick();
    if (isVictoryComic)
      this.closeButton.onClick += (System.Action) (() =>
      {
        this.Stop();
        this.Show(false);
      });
    else
      this.closeButton.onClick += (System.Action) (() => this.Stop());
  }

  public void Stop()
  {
    this.OnStop();
    this.Show(false);
    this.gameObject.SetActive(false);
  }
}

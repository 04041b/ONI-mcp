// Decompiled with JetBrains decompiler
// Type: KPopupMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class KPopupMenu : KScreen
{
  [SerializeField]
  private KButtonMenu buttonMenu;
  private KButtonMenu.ButtonInfo[] Buttons;
  public Action<string, int> OnSelect;

  public void SetOptions(IList<string> options)
  {
    List<KButtonMenu.ButtonInfo> buttonInfoList = new List<KButtonMenu.ButtonInfo>();
    for (int index1 = 0; index1 < options.Count; ++index1)
    {
      int index = index1;
      string option = options[index1];
      buttonInfoList.Add(new KButtonMenu.ButtonInfo(option, Action.NumActions, (UnityAction) (() => this.SelectOption(option, index))));
    }
    this.Buttons = buttonInfoList.ToArray();
  }

  public void OnClick()
  {
    if (this.Buttons == null)
      return;
    if (this.gameObject.activeSelf)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      this.buttonMenu.SetButtons((IList<KButtonMenu.ButtonInfo>) this.Buttons);
      this.buttonMenu.RefreshButtons();
      this.gameObject.SetActive(true);
    }
  }

  public void SelectOption(string option, int index)
  {
    if (this.OnSelect != null)
      this.OnSelect(option, index);
    this.gameObject.SetActive(false);
  }

  public IList<KButtonMenu.ButtonInfo> GetButtons() => (IList<KButtonMenu.ButtonInfo>) this.Buttons;
}

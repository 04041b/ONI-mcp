// Decompiled with JetBrains decompiler
// Type: LoreBearer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/LoreBearer")]
public class LoreBearer : KMonoBehaviour
{
  [Serialize]
  private bool BeenClicked;
  public string BeenSearched = (string) UI.USERMENUACTIONS.READLORE.ALREADY_SEARCHED;
  private string[] collectionsToUnlockFrom;
  public Func<int> GetSidescreenSortOrder;
  private LoreBearerAction displayContentAction;

  public string content
  {
    get => (string) Strings.Get($"STRINGS.LORE.BUILDINGS.{this.gameObject.name}.ENTRY");
  }

  protected override void OnSpawn() => base.OnSpawn();

  public LoreBearer Internal_SetContent(LoreBearerAction action)
  {
    this.displayContentAction = action;
    return this;
  }

  public LoreBearer Internal_SetContent(LoreBearerAction action, string[] collectionsToUnlockFrom)
  {
    this.displayContentAction = action;
    this.collectionsToUnlockFrom = collectionsToUnlockFrom;
    return this;
  }

  public static InfoDialogScreen ShowPopupDialog()
  {
    return (InfoDialogScreen) GameScreenManager.Instance.StartScreen(ScreenPrefabs.Instance.InfoDialogScreen.gameObject, GameScreenManager.Instance.ssOverlayCanvas.gameObject);
  }

  private void OnClickRead()
  {
    InfoDialogScreen screen = LoreBearer.ShowPopupDialog().SetHeader(this.gameObject.GetComponent<KSelectable>().GetProperName()).AddDefaultOK(true);
    if (this.BeenClicked)
    {
      screen.AddPlainText(this.BeenSearched);
    }
    else
    {
      this.BeenClicked = true;
      if (DlcManager.IsExpansion1Active())
      {
        Scenario.SpawnPrefab(Grid.PosToCell(this.gameObject), 0, 1, "OrbitalResearchDatabank", Grid.SceneLayer.Front).SetActive(true);
        PopFXManager.Instance.SpawnFX(PopFXManager.Instance.sprite_Plus, Assets.GetPrefab("OrbitalResearchDatabank".ToTag()).GetProperName(), this.gameObject.transform);
      }
      if (this.displayContentAction != null)
        this.displayContentAction(screen);
      else
        LoreBearerUtil.UnlockNextJournalEntry(screen);
    }
  }

  public string SidescreenButtonText
  {
    get
    {
      return (string) (this.BeenClicked ? UI.USERMENUACTIONS.READLORE.ALREADYINSPECTED : UI.USERMENUACTIONS.READLORE.NAME);
    }
  }

  public string SidescreenButtonTooltip
  {
    get
    {
      return (string) (this.BeenClicked ? UI.USERMENUACTIONS.READLORE.TOOLTIP_ALREADYINSPECTED : UI.USERMENUACTIONS.READLORE.TOOLTIP);
    }
  }

  public void OnSidescreenButtonPressed() => this.OnClickRead();

  public bool SidescreenButtonInteractable() => !this.BeenClicked;

  public int GetSideScreenSortOrder()
  {
    return this.GetSidescreenSortOrder != null ? this.GetSidescreenSortOrder() : -100;
  }
}

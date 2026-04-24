// Decompiled with JetBrains decompiler
// Type: LockerMenuScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class LockerMenuScreen : KModalScreen
{
  public static LockerMenuScreen Instance;
  [SerializeField]
  private MultiToggle buttonInventory;
  [SerializeField]
  private MultiToggle buttonDuplicants;
  [SerializeField]
  private MultiToggle buttonOutfitBroswer;
  [SerializeField]
  private MultiToggle buttonClaimItems;
  [SerializeField]
  private LocText descriptionArea;
  [SerializeField]
  private KButton closeButton;
  [SerializeField]
  private GameObject dropsAvailableNotification;
  [SerializeField]
  private GameObject noConnectionIcon;
  private const string LOCKER_MENU_MUSIC = "Music_SupplyCloset";
  private const string MUSIC_PARAMETER = "SupplyClosetView";
  [SerializeField]
  private Material desatUIMaterial;
  private bool refreshRequested;
  [SerializeField]
  private GameObject DLCLogoContainer;
  [SerializeField]
  private GameObject DLCLogoPrefab;

  protected override void OnActivate()
  {
    LockerMenuScreen.Instance = this;
    this.Show(false);
  }

  public override float GetSortKey() => 40f;

  public void ShowInventoryScreen()
  {
    if (!this.isActiveAndEnabled)
      this.Show(true);
    LockerNavigator.Instance.PushScreen(LockerNavigator.Instance.kleiInventoryScreen);
    MusicManager.instance.SetSongParameter("Music_SupplyCloset", "SupplyClosetView", "inventory");
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.buttonInventory.onClick += (System.Action) (() => this.ShowInventoryScreen());
    this.buttonDuplicants.onClick += (System.Action) (() =>
    {
      MinionBrowserScreenConfig.Personalities().ApplyAndOpenScreen();
      MusicManager.instance.SetSongParameter("Music_SupplyCloset", "SupplyClosetView", "dupe");
    });
    this.buttonOutfitBroswer.onClick += (System.Action) (() =>
    {
      OutfitBrowserScreenConfig.Mannequin().ApplyAndOpenScreen();
      MusicManager.instance.SetSongParameter("Music_SupplyCloset", "SupplyClosetView", "wardrobe");
    });
    this.closeButton.onClick += (System.Action) (() => this.Show(false));
    this.ConfigureHoverForButton(this.buttonInventory, (string) STRINGS.UI.LOCKER_MENU.BUTTON_INVENTORY_DESCRIPTION);
    this.ConfigureHoverForButton(this.buttonDuplicants, (string) STRINGS.UI.LOCKER_MENU.BUTTON_DUPLICANTS_DESCRIPTION);
    this.ConfigureHoverForButton(this.buttonOutfitBroswer, (string) STRINGS.UI.LOCKER_MENU.BUTTON_OUTFITS_DESCRIPTION);
    this.descriptionArea.text = (string) STRINGS.UI.LOCKER_MENU.DEFAULT_DESCRIPTION;
    this.CreateDLCLogos();
  }

  private void ConfigureHoverForButton(MultiToggle toggle, string desc, bool useHoverColor = true)
  {
    Color defaultColor = new Color(0.309803933f, 0.34117648f, 0.384313732f, 1f);
    Color hoverColor = new Color(0.7019608f, 0.3647059f, 0.533333361f, 1f);
    toggle.onEnter = (System.Action) null;
    toggle.onExit = (System.Action) null;
    toggle.onEnter += OnHoverEnterFn(toggle, desc);
    toggle.onExit += OnHoverExitFn(toggle);

    System.Action OnHoverEnterFn(MultiToggle toggle, string desc)
    {
      Image headerBackground = toggle.GetComponent<HierarchyReferences>().GetReference<RectTransform>("HeaderBackground").GetComponent<Image>();
      return (System.Action) (() =>
      {
        KMonoBehaviour.PlaySound(GlobalAssets.GetSound("HUD_Mouseover"));
        if (useHoverColor)
          headerBackground.color = hoverColor;
        this.descriptionArea.text = desc;
      });
    }

    System.Action OnHoverExitFn(MultiToggle toggle)
    {
      Image headerBackground = toggle.GetComponent<HierarchyReferences>().GetReference<RectTransform>("HeaderBackground").GetComponent<Image>();
      return (System.Action) (() =>
      {
        KMonoBehaviour.PlaySound(GlobalAssets.GetSound("HUD_Mouseover"));
        if (useHoverColor)
          headerBackground.color = defaultColor;
        this.descriptionArea.text = (string) STRINGS.UI.LOCKER_MENU.DEFAULT_DESCRIPTION;
      });
    }
  }

  public override void Show(bool show = true)
  {
    base.Show(show);
    if (show)
    {
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndSupplyClosetSnapshot);
      MusicManager.instance.OnSupplyClosetMenu(true, 0.5f);
      MusicManager.instance.PlaySong("Music_SupplyCloset");
      ThreadedHttps<KleiAccount>.Instance.AuthenticateUser(new KleiAccount.GetUserIDdelegate(this.TriggerShouldRefreshClaimItems));
    }
    else
    {
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndSupplyClosetSnapshot);
      MusicManager.instance.OnSupplyClosetMenu(false, 1f);
      if (MusicManager.instance.SongIsPlaying("Music_SupplyCloset"))
        MusicManager.instance.StopSong("Music_SupplyCloset");
    }
    this.RefreshClaimItemsButton();
  }

  private void TriggerShouldRefreshClaimItems() => this.refreshRequested = true;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (!KPrivacyPrefs.instance.disableDataCollection)
      return;
    this.noConnectionIcon.GetComponent<ToolTip>().SetSimpleTooltip((string) STRINGS.UI.LOCKER_MENU.OFFLINE_ICON_TOOLTIP_DATA_COLLECTIONS);
  }

  protected override void OnForcedCleanUp() => base.OnForcedCleanUp();

  private void RefreshClaimItemsButton()
  {
    this.noConnectionIcon.SetActive(!ThreadedHttps<KleiAccount>.Instance.HasValidTicket());
    this.refreshRequested = false;
    bool hasClaimable = PermitItems.HasUnopenedItem();
    this.dropsAvailableNotification.SetActive(hasClaimable);
    this.buttonClaimItems.ChangeState(hasClaimable ? 0 : 1);
    this.buttonClaimItems.GetComponent<HierarchyReferences>().GetReference<Image>("FGIcon").material = hasClaimable ? (Material) null : this.desatUIMaterial;
    this.buttonClaimItems.onClick = (System.Action) null;
    this.buttonClaimItems.onClick += (System.Action) (() =>
    {
      if (!hasClaimable)
        return;
      UnityEngine.Object.FindFirstObjectByType<KleiItemDropScreen>(FindObjectsInactive.Include).Show(true);
      this.Show(false);
    });
    this.ConfigureHoverForButton(this.buttonClaimItems, (string) (hasClaimable ? STRINGS.UI.LOCKER_MENU.BUTTON_CLAIM_DESCRIPTION : STRINGS.UI.LOCKER_MENU.BUTTON_CLAIM_NONE_DESCRIPTION), hasClaimable);
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (e.TryConsume(Action.Escape) || e.TryConsume(Action.MouseRight))
    {
      this.Show(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndSupplyClosetSnapshot);
      MusicManager.instance.OnSupplyClosetMenu(false, 1f);
      if (MusicManager.instance.SongIsPlaying("Music_SupplyCloset"))
        MusicManager.instance.StopSong("Music_SupplyCloset");
    }
    base.OnKeyDown(e);
  }

  private void Update()
  {
    if (!this.refreshRequested)
      return;
    this.RefreshClaimItemsButton();
  }

  private void CreateDLCLogos()
  {
    foreach (KeyValuePair<string, DlcManager.DlcInfo> keyValuePair in DlcManager.DLC_PACKS)
    {
      KeyValuePair<string, DlcManager.DlcInfo> dlc = keyValuePair;
      if (dlc.Value.isCosmetic)
      {
        GameObject gameObject = Util.KInstantiateUI(this.DLCLogoPrefab, this.DLCLogoContainer, true);
        Image component = gameObject.GetComponent<Image>();
        component.sprite = Assets.GetSprite((HashedString) DlcManager.GetDlcLargeLogo(dlc.Key));
        component.material = DlcManager.IsContentSubscribed(dlc.Key) ? GlobalResources.Instance().AnimUIMaterial : GlobalResources.Instance().AnimMaterialUIDesaturated;
        gameObject.GetComponent<MultiToggle>().states[0].sprite = Assets.GetSprite((HashedString) DlcManager.GetDlcSmallLogo(dlc.Key));
        string dlcTitle = DlcManager.GetDlcTitle(dlc.Key);
        string message;
        if (!DlcManager.IsContentSubscribed(dlc.Key))
          message = $"{dlcTitle}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
        else
          message = $"{dlcTitle}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_INSTALLED_LABEL}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.DLC.COSMETIC_CONTENT_ACTIVE_TOOLTIP}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
        gameObject.GetComponent<ToolTip>().SetSimpleTooltip(message);
        gameObject.GetComponent<MultiToggle>().onClick += (System.Action) (() => App.OpenWebURL(this.GetCosmeticDLCStoreURL(dlc.Key)));
        gameObject.gameObject.SetActive(true);
      }
    }
  }

  private string GetCosmeticDLCStoreURL(string dlcId)
  {
    if (DistributionPlatform.Initialized || Application.isEditor)
    {
      if (DistributionPlatform.Inst.Name == "Steam")
        return dlcId == "COSMETIC1_ID" ? "https://store.steampowered.com/app/4157740/Oxygen_Not_Included_Neutronium_Cosmetics_Pack/" : "";
      if (DistributionPlatform.Inst.Name == "Epic")
        return dlcId == "COSMETIC1_ID" ? "https://store.epicgames.com/p/oxygen-not-included-oxygen-not-included-neutronium-cosmetics-pack-d9e8af" : "";
      if (DistributionPlatform.Inst.Name == "Rail" && dlcId == "COSMETIC1_ID")
        return "https://www.wegame.com.cn/store/2002628";
    }
    return "";
  }
}

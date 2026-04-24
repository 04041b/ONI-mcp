// Decompiled with JetBrains decompiler
// Type: ManagementScreenNotificationOverlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ManagementScreenNotificationOverlay : KMonoBehaviour
{
  public Action currentMenu;
  public NotificationAlertBar alertBarPrefab;
  public RectTransform alertContainer;
  private List<NotificationAlertBar> alertBars = new List<NotificationAlertBar>();

  protected void OnEnable()
  {
  }

  protected override void OnDisable()
  {
  }

  private NotificationAlertBar CreateAlertBar(ManagementMenuNotification notification)
  {
    NotificationAlertBar alertBar = Util.KInstantiateUI<NotificationAlertBar>(this.alertBarPrefab.gameObject, this.alertContainer.gameObject);
    alertBar.Init(notification);
    alertBar.gameObject.SetActive(true);
    return alertBar;
  }

  private void NotificationsChanged()
  {
  }
}

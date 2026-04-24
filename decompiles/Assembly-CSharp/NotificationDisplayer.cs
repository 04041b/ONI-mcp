// Decompiled with JetBrains decompiler
// Type: NotificationDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public abstract class NotificationDisplayer : KMonoBehaviour
{
  protected List<Notification> displayedNotifications;

  protected override void OnSpawn()
  {
    this.displayedNotifications = new List<Notification>();
    NotificationManager.Instance.notificationAdded += new Action<Notification>(this.NotificationAdded);
    NotificationManager.Instance.notificationRemoved += new Action<Notification>(this.NotificationRemoved);
  }

  public void NotificationAdded(Notification notification)
  {
    if (!this.ShouldDisplayNotification(notification))
      return;
    this.displayedNotifications.Add(notification);
    this.OnNotificationAdded(notification);
  }

  protected abstract void OnNotificationAdded(Notification notification);

  public void NotificationRemoved(Notification notification)
  {
    if (!this.displayedNotifications.Contains(notification))
      return;
    this.displayedNotifications.Remove(notification);
    this.OnNotificationRemoved(notification);
  }

  protected abstract void OnNotificationRemoved(Notification notification);

  protected abstract bool ShouldDisplayNotification(Notification notification);
}

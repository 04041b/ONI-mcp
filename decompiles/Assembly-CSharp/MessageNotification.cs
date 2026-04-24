// Decompiled with JetBrains decompiler
// Type: MessageNotification
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MessageNotification : Notification
{
  public Message message;

  private string OnToolTip(List<Notification> notifications, string tooltipText) => tooltipText;

  public MessageNotification(Message m)
    : base(m.GetTitle(), NotificationType.Messages, expires: false, show_dismiss_button: true)
  {
    MessageNotification messageNotification = this;
    this.message = m;
    this.Type = m.GetMessageType();
    this.showDismissButton = m.ShowDismissButton();
    if (!this.message.PlayNotificationSound())
      this.playSound = false;
    this.ToolTip = (Func<List<Notification>, object, string>) ((notifications, data) => messageNotification.OnToolTip(notifications, m.GetTooltip()));
    this.clickFocus = (Transform) null;
  }
}

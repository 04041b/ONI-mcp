// Decompiled with JetBrains decompiler
// Type: NotificationHighlightTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NotificationHighlightTarget : KMonoBehaviour
{
  public string targetKey;
  private NotificationHighlightController controller;

  protected void OnEnable()
  {
    this.controller = this.GetComponentInParent<NotificationHighlightController>();
    if (!((Object) this.controller != (Object) null))
      return;
    this.controller.AddTarget(this);
  }

  protected override void OnDisable()
  {
    if (!((Object) this.controller != (Object) null))
      return;
    this.controller.RemoveTarget(this);
  }

  public void View()
  {
    this.GetComponentInParent<NotificationHighlightController>().TargetViewed(this);
  }
}

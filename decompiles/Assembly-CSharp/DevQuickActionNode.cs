// Decompiled with JetBrains decompiler
// Type: DevQuickActionNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TMPro;
using UnityEngine;

#nullable disable
public class DevQuickActionNode : MonoBehaviour
{
  public TextMeshProUGUI label;
  protected DevQuickActionNode parentNode;
  public Action<DevQuickActionNode> OnRecycle;
  protected System.Action OnNodeInteractedWith;
  protected float space = 100f;

  public RectTransform transform => base.transform as RectTransform;

  public void SetChildrenSeparationSpace(float space) => this.space = space;

  public virtual void Recycle()
  {
    this.parentNode = (DevQuickActionNode) null;
    this.OnNodeInteractedWith = (System.Action) null;
    this.gameObject.SetActive(false);
    Action<DevQuickActionNode> onRecycle = this.OnRecycle;
    if (onRecycle == null)
      return;
    onRecycle(this);
  }
}

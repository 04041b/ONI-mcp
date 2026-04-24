// Decompiled with JetBrains decompiler
// Type: DetailLabelWithButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/DetailLabelWithButton")]
public class DetailLabelWithButton : KMonoBehaviour
{
  public LocText label;
  public LocText label2;
  public LocText label3;
  public ToolTip toolTip;
  public KButton button;

  public void RefreshLabelsVisibility()
  {
    if (this.label.gameObject.activeInHierarchy != !string.IsNullOrEmpty(this.label.text))
      this.label.gameObject.SetActive(!string.IsNullOrEmpty(this.label.text));
    if (this.label2.gameObject.activeInHierarchy != !string.IsNullOrEmpty(this.label2.text))
      this.label2.gameObject.SetActive(!string.IsNullOrEmpty(this.label2.text));
    if (this.label3.gameObject.activeInHierarchy == !string.IsNullOrEmpty(this.label3.text))
      return;
    this.label3.gameObject.SetActive(!string.IsNullOrEmpty(this.label3.text));
  }
}

// Decompiled with JetBrains decompiler
// Type: InfoScreenLineItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/InfoScreenLineItem")]
public class InfoScreenLineItem : KMonoBehaviour
{
  [SerializeField]
  private LocText locText;
  [SerializeField]
  private ToolTip toolTip;
  private string text;
  private string tooltip;

  public void SetText(string text) => this.locText.text = text;

  public void SetTooltip(string tooltip) => this.toolTip.toolTip = tooltip;
}

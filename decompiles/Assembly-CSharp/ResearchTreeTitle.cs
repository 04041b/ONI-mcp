// Decompiled with JetBrains decompiler
// Type: ResearchTreeTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ResearchTreeTitle : MonoBehaviour
{
  [Header("References")]
  [SerializeField]
  private LocText treeLabel;
  [SerializeField]
  private Image BG;

  public void SetLabel(string txt) => this.treeLabel.text = txt;

  public void SetColor(int id) => this.BG.enabled = id % 2 != 0;
}

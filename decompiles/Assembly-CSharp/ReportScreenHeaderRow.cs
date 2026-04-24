// Decompiled with JetBrains decompiler
// Type: ReportScreenHeaderRow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ReportScreenHeaderRow")]
public class ReportScreenHeaderRow : KMonoBehaviour
{
  [SerializeField]
  public LocText name;
  [SerializeField]
  private LayoutElement spacer;
  [SerializeField]
  private Image bgImage;
  public float groupSpacerWidth;
  private float nameWidth = 164f;
  [SerializeField]
  private Color oddRowColor;

  public void SetLine(ReportManager.ReportGroup reportGroup)
  {
    LayoutElement component = this.name.GetComponent<LayoutElement>();
    double nameWidth;
    float num = (float) (nameWidth = (double) this.nameWidth);
    component.preferredWidth = (float) nameWidth;
    component.minWidth = num;
    this.spacer.minWidth = this.groupSpacerWidth;
    this.name.text = reportGroup.stringKey;
  }
}

// Decompiled with JetBrains decompiler
// Type: AlternateSiblingColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class AlternateSiblingColor : KMonoBehaviour
{
  public Color evenColor;
  public Color oddColor;
  public Image image;
  private int mySiblingIndex;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.RefreshColor(this.transform.GetSiblingIndex() % 2 == 0);
  }

  private void RefreshColor(bool evenIndex)
  {
    if ((Object) this.image == (Object) null)
      return;
    this.image.color = evenIndex ? this.evenColor : this.oddColor;
  }

  private void Update()
  {
    if (this.mySiblingIndex == this.transform.GetSiblingIndex())
      return;
    this.mySiblingIndex = this.transform.GetSiblingIndex();
    this.RefreshColor(this.mySiblingIndex % 2 == 0);
  }
}

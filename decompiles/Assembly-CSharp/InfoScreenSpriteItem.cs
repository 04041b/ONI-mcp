// Decompiled with JetBrains decompiler
// Type: InfoScreenSpriteItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/InfoScreenSpriteItem")]
public class InfoScreenSpriteItem : KMonoBehaviour
{
  [SerializeField]
  private Image image;
  [SerializeField]
  private LayoutElement layout;

  public void SetSprite(Sprite sprite)
  {
    this.image.sprite = sprite;
    UnityEngine.Rect rect = sprite.rect;
    double width = (double) rect.width;
    rect = sprite.rect;
    double height = (double) rect.height;
    this.layout.preferredWidth = this.layout.preferredHeight * (float) (width / height);
  }
}

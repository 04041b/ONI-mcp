// Decompiled with JetBrains decompiler
// Type: CodexLabelWithIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class CodexLabelWithIcon : CodexWidget<CodexLabelWithIcon>
{
  public CodexImage icon { get; set; }

  public CodexText label { get; set; }

  public string stringKey { get; set; } = "";

  public string batchedAnimPrefabSourceID { get; set; } = "";

  public string spriteName { get; set; } = "";

  public CodexLabelWithIcon()
  {
    this.icon = new CodexImage();
    this.label = new CodexText();
  }

  public CodexLabelWithIcon(string text, CodexTextStyle style, Tuple<Sprite, Color> coloredSprite)
  {
    this.icon = new CodexImage(coloredSprite);
    this.label = new CodexText(text, style);
  }

  public CodexLabelWithIcon(
    string text,
    CodexTextStyle style,
    Tuple<Sprite, Color> coloredSprite,
    int iconWidth,
    int iconHeight)
  {
    this.icon = new CodexImage(iconWidth, iconHeight, coloredSprite);
    this.label = new CodexText(text, style);
  }

  public override void Configure(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    if (!string.IsNullOrEmpty(this.stringKey))
      this.label.stringKey = this.stringKey;
    if (!string.IsNullOrEmpty(this.batchedAnimPrefabSourceID))
    {
      GameObject prefab = Assets.TryGetPrefab((Tag) this.batchedAnimPrefabSourceID);
      KBatchedAnimController component = (Object) prefab != (Object) null ? prefab.GetComponent<KBatchedAnimController>() : (KBatchedAnimController) null;
      KAnimFile animFile = (Object) component != (Object) null ? component.AnimFiles[0] : (KAnimFile) null;
      this.icon.sprite = (Object) animFile != (Object) null ? Def.GetUISpriteFromMultiObjectAnim(animFile) : (Sprite) null;
    }
    if (!string.IsNullOrEmpty(this.spriteName))
      this.icon.sprite = Assets.GetSprite((HashedString) this.spriteName);
    this.icon.ConfigureImage(contentGameObject.GetComponentInChildren<Image>());
    if (this.icon.preferredWidth != -1 && this.icon.preferredHeight != -1)
    {
      LayoutElement component = contentGameObject.GetComponentInChildren<Image>().GetComponent<LayoutElement>();
      component.minWidth = (float) this.icon.preferredHeight;
      component.minHeight = (float) this.icon.preferredWidth;
      component.preferredHeight = (float) this.icon.preferredHeight;
      component.preferredWidth = (float) this.icon.preferredWidth;
    }
    this.label.ConfigureLabel(contentGameObject.GetComponentInChildren<LocText>(), textStyles);
  }
}

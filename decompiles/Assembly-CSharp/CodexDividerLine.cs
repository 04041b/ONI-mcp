// Decompiled with JetBrains decompiler
// Type: CodexDividerLine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class CodexDividerLine : CodexWidget<CodexDividerLine>
{
  public override void Configure(
    GameObject contentGameObject,
    Transform displayPane,
    Dictionary<CodexTextStyle, TextStyleSetting> textStyles)
  {
    contentGameObject.GetComponent<LayoutElement>().minWidth = 530f;
  }
}

// Decompiled with JetBrains decompiler
// Type: RestartWarning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class RestartWarning : MonoBehaviour
{
  public static bool ShouldWarn;
  public LocText text;
  public Image image;

  private void Update()
  {
    if (!RestartWarning.ShouldWarn)
      return;
    this.text.enabled = true;
    this.image.enabled = true;
  }
}

// Decompiled with JetBrains decompiler
// Type: FeedbackTextFix
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Steamworks;
using UnityEngine;

#nullable disable
public class FeedbackTextFix : MonoBehaviour
{
  public string newKey;
  public LocText locText;

  private void Awake()
  {
    if (!DistributionPlatform.Initialized || !SteamUtils.IsSteamRunningOnSteamDeck())
      Object.DestroyImmediate((Object) this);
    else
      this.locText.key = this.newKey;
  }
}

// Decompiled with JetBrains decompiler
// Type: FillRenderTargetEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FillRenderTargetEffect : MonoBehaviour
{
  private Texture fillTexture;

  public void SetFillTexture(Texture tex) => this.fillTexture = tex;

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    Graphics.Blit(this.fillTexture, (RenderTexture) null);
  }
}

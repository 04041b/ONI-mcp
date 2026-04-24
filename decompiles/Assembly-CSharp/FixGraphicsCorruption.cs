// Decompiled with JetBrains decompiler
// Type: FixGraphicsCorruption
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FixGraphicsCorruption : MonoBehaviour
{
  private void Start()
  {
    Camera component = this.GetComponent<Camera>();
    component.transparencySortMode = TransparencySortMode.Orthographic;
    component.tag = "Untagged";
  }

  private void OnRenderImage(RenderTexture source, RenderTexture dest)
  {
    Graphics.Blit((Texture) source, dest);
  }
}

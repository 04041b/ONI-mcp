// Decompiled with JetBrains decompiler
// Type: VisualizerEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class VisualizerEffect : MonoBehaviour
{
  protected Material material;
  protected Camera myCamera;
  protected Texture2D OcclusionTex;

  protected abstract void SetupMaterial();

  protected abstract void SetupOcclusionTex();

  protected abstract void OnPostRender();

  protected virtual void Start()
  {
    this.SetupMaterial();
    this.SetupOcclusionTex();
    this.myCamera = this.GetComponent<Camera>();
  }
}

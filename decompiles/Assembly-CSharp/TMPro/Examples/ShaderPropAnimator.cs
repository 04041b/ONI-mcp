// Decompiled with JetBrains decompiler
// Type: TMPro.Examples.ShaderPropAnimator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace TMPro.Examples;

public class ShaderPropAnimator : MonoBehaviour
{
  private Renderer m_Renderer;
  private Material m_Material;
  public AnimationCurve GlowCurve;
  public float m_frame;

  private void Awake()
  {
    this.m_Renderer = this.GetComponent<Renderer>();
    this.m_Material = this.m_Renderer.material;
  }

  private void Start() => this.StartCoroutine(this.AnimateProperties());

  private IEnumerator AnimateProperties()
  {
    this.m_frame = Random.Range(0.0f, 1f);
    while (true)
    {
      float num = this.GlowCurve.Evaluate(this.m_frame);
      this.m_Material.SetFloat(ShaderUtilities.ID_GlowPower, num);
      this.m_frame += Time.deltaTime * Random.Range(0.2f, 0.3f);
      yield return (object) new WaitForEndOfFrame();
    }
  }
}

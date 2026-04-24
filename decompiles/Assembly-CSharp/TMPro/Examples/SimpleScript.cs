// Decompiled with JetBrains decompiler
// Type: TMPro.Examples.SimpleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace TMPro.Examples;

public class SimpleScript : MonoBehaviour
{
  private TextMeshPro m_textMeshPro;
  private const string label = "The <#0050FF>count is: </color>{0:2}";
  private float m_frame;

  private void Start()
  {
    this.m_textMeshPro = this.gameObject.AddComponent<TextMeshPro>();
    this.m_textMeshPro.autoSizeTextContainer = true;
    this.m_textMeshPro.fontSize = 48f;
    this.m_textMeshPro.alignment = TextAlignmentOptions.Center;
    this.m_textMeshPro.textWrappingMode = TextWrappingModes.NoWrap;
  }

  private void Update()
  {
    this.m_textMeshPro.SetText("The <#0050FF>count is: </color>{0:2}", this.m_frame % 1000f);
    this.m_frame += 1f * Time.deltaTime;
  }
}

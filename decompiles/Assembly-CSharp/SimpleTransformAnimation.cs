// Decompiled with JetBrains decompiler
// Type: SimpleTransformAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SimpleTransformAnimation : MonoBehaviour
{
  [SerializeField]
  private Vector3 rotationSpeed;
  [SerializeField]
  private Vector3 translateSpeed;

  private void Start()
  {
  }

  private void Update()
  {
    this.transform.Rotate(this.rotationSpeed * Time.unscaledDeltaTime);
    this.transform.Translate(this.translateSpeed * Time.unscaledDeltaTime);
  }
}

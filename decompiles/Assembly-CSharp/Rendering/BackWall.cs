// Decompiled with JetBrains decompiler
// Type: rendering.BackWall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace rendering;

public class BackWall : MonoBehaviour
{
  [SerializeField]
  public Material backwallMaterial;
  [SerializeField]
  public Texture2DArray array;

  private void Awake() => this.backwallMaterial.SetTexture("images", (Texture) this.array);
}

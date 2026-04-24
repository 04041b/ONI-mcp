// Decompiled with JetBrains decompiler
// Type: ClusterMapIconFixRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ClusterMapIconFixRotation : KMonoBehaviour
{
  [MyCmpGet]
  private KBatchedAnimController animController;
  private float rotation;

  private void Update()
  {
    if (!((Object) this.transform.parent != (Object) null))
      return;
    this.rotation = -this.transform.parent.rotation.eulerAngles.z;
    this.animController.Rotation = this.rotation;
  }
}

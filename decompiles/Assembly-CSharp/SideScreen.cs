// Decompiled with JetBrains decompiler
// Type: SideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SideScreen : KScreen
{
  [SerializeField]
  private GameObject contentBody;

  public void SetContent(SideScreenContent sideScreenContent, GameObject target)
  {
    if ((Object) sideScreenContent.transform.parent != (Object) this.contentBody.transform)
      sideScreenContent.transform.SetParent(this.contentBody.transform);
    sideScreenContent.SetTarget(target);
  }
}

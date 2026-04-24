// Decompiled with JetBrains decompiler
// Type: NotCapturable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/NotCapturable")]
public class NotCapturable : KMonoBehaviour
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    if ((Object) this.GetComponent<Capturable>() != (Object) null)
      DebugUtil.LogErrorArgs((Object) this, (object) "Entity has both Capturable and NotCapturable!");
    Components.NotCapturables.Add(this);
  }

  protected override void OnCleanUp()
  {
    Components.NotCapturables.Remove(this);
    base.OnCleanUp();
  }
}

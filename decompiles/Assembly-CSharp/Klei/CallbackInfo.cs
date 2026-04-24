// Decompiled with JetBrains decompiler
// Type: Klei.CallbackInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei;

public struct CallbackInfo(HandleVector<Game.CallbackInfo>.Handle h)
{
  private HandleVector<Game.CallbackInfo>.Handle handle = h;

  public void Release()
  {
    if (!this.handle.IsValid())
      return;
    Game.CallbackInfo callbackInfo = Game.Instance.callbackManager.GetItem(this.handle);
    System.Action cb = callbackInfo.cb;
    if (!callbackInfo.manuallyRelease)
      Game.Instance.callbackManager.Release(this.handle);
    cb();
  }
}

// Decompiled with JetBrains decompiler
// Type: CancellableDig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[SkipSaveFileSerialization]
public class CancellableDig : Cancellable
{
  protected override void OnCancel(object data)
  {
    if ((data == null || !(data is Boxed<bool> boxed) ? 0 : (boxed.value ? 1 : 0)) != 0)
    {
      this.OnAnimationDone("ScaleDown");
    }
    else
    {
      EasingAnimations componentInChildren = this.GetComponentInChildren<EasingAnimations>();
      int cell = Grid.PosToCell((KMonoBehaviour) this);
      if (componentInChildren.IsPlaying && Grid.Element[cell].hardness == byte.MaxValue)
      {
        componentInChildren.OnAnimationDone += new Action<string>(this.DoCancelAnim);
      }
      else
      {
        componentInChildren.OnAnimationDone += new Action<string>(this.OnAnimationDone);
        componentInChildren.PlayAnimation("ScaleDown", 0.1f);
      }
    }
  }

  private void DoCancelAnim(string animName)
  {
    EasingAnimations componentInChildren = this.GetComponentInChildren<EasingAnimations>();
    componentInChildren.OnAnimationDone -= new Action<string>(this.DoCancelAnim);
    componentInChildren.OnAnimationDone += new Action<string>(this.OnAnimationDone);
    componentInChildren.PlayAnimation("ScaleDown", 0.1f);
  }

  private void OnAnimationDone(string animationName)
  {
    if (animationName != "ScaleDown")
      return;
    this.GetComponentInChildren<EasingAnimations>().OnAnimationDone -= new Action<string>(this.OnAnimationDone);
    this.DeleteObject();
  }
}

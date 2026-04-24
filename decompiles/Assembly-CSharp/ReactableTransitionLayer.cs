// Decompiled with JetBrains decompiler
// Type: ReactableTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ReactableTransitionLayer(Navigator navigator) : TransitionDriver.InterruptOverrideLayer(navigator)
{
  private ReactionMonitor.Instance reactionMonitor;

  protected override bool IsOverrideComplete()
  {
    return !this.reactionMonitor.IsReacting() && base.IsOverrideComplete();
  }

  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    if (this.reactionMonitor == null)
      this.reactionMonitor = navigator.GetSMI<ReactionMonitor.Instance>();
    this.reactionMonitor.PollForReactables(transition);
    if (!this.reactionMonitor.IsReacting())
      return;
    base.BeginTransition(navigator, transition);
    transition.start = this.originalTransition.start;
    transition.end = this.originalTransition.end;
  }
}

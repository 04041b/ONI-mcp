// Decompiled with JetBrains decompiler
// Type: NewGameFlowScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class NewGameFlowScreen : KModalScreen
{
  public event System.Action OnNavigateForward;

  public event System.Action OnNavigateBackward;

  protected void NavigateBackward() => this.OnNavigateBackward();

  protected void NavigateForward() => this.OnNavigateForward();

  public override void OnKeyDown(KButtonEvent e)
  {
    if (e.Consumed)
      return;
    if (e.TryConsume(Action.MouseRight))
      this.NavigateBackward();
    base.OnKeyDown(e);
  }
}

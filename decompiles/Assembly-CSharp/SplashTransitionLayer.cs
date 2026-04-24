// Decompiled with JetBrains decompiler
// Type: SplashTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SplashTransitionLayer : TransitionDriver.OverrideLayer
{
  private float lastSplashTime;
  private const float SPLASH_INTERVAL = 1f;

  public SplashTransitionLayer(Navigator navigator)
    : base(navigator)
  {
    this.lastSplashTime = Time.time;
  }

  private void RefreshSplashes(Navigator navigator, Navigator.ActiveTransition transition)
  {
    if ((Object) navigator == (Object) null || transition.end == NavType.Tube)
      return;
    Vector3 position = navigator.transform.GetPosition();
    if ((double) this.lastSplashTime + 1.0 >= (double) Time.time || !Grid.Element[Grid.PosToCell(position)].IsLiquid)
      return;
    this.lastSplashTime = Time.time;
    Game.Instance.SpawnFX(SpawnFXHashes.SplashStep, position + new Vector3(0.0f, 0.75f, -0.1f), 0.0f);
  }

  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.BeginTransition(navigator, transition);
    this.RefreshSplashes(navigator, transition);
  }

  public override void UpdateTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.UpdateTransition(navigator, transition);
    this.RefreshSplashes(navigator, transition);
  }

  public override void EndTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.EndTransition(navigator, transition);
    this.RefreshSplashes(navigator, transition);
  }
}

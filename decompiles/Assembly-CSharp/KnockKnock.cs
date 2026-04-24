// Decompiled with JetBrains decompiler
// Type: KnockKnock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class KnockKnock : Activatable
{
  private bool doorAnswered;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.showProgressBar = false;
  }

  protected override bool OnWorkTick(WorkerBase worker, float dt)
  {
    if (!this.doorAnswered)
      this.workTimeRemaining += dt;
    return base.OnWorkTick(worker, dt);
  }

  public void AnswerDoor()
  {
    this.doorAnswered = true;
    this.workTimeRemaining = 1f;
  }
}

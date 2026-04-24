// Decompiled with JetBrains decompiler
// Type: LiquidCooledFanWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/LiquidCooledFanWorkable")]
public class LiquidCooledFanWorkable : Workable
{
  [MyCmpGet]
  private Operational operational;

  private LiquidCooledFanWorkable() => this.showProgressBar = false;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = (StatusItem) null;
  }

  protected override void OnSpawn()
  {
    GameScheduler.Instance.Schedule("InsulationTutorial", 2f, (Action<object>) (obj => Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_Insulation)), (object) null, (SchedulerGroup) null);
    base.OnSpawn();
  }

  protected override void OnStartWork(WorkerBase worker) => this.operational.SetActive(true);

  protected override void OnStopWork(WorkerBase worker) => this.operational.SetActive(false);

  protected override void OnCompleteWork(WorkerBase worker) => this.operational.SetActive(false);
}

// Decompiled with JetBrains decompiler
// Type: ProcessCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine.Pool;

#nullable disable
public abstract class ProcessCondition
{
  protected ProcessCondition parentCondition;
  public static ObjectPool<List<ProcessCondition>> ListPool = new ObjectPool<List<ProcessCondition>>((Func<List<ProcessCondition>>) (() => new List<ProcessCondition>(16 /*0x10*/)), actionOnRelease: (Action<List<ProcessCondition>>) (list => list.Clear()), collectionCheck: false, defaultCapacity: 4, maxSize: 4);

  public abstract ProcessCondition.Status EvaluateCondition();

  public abstract bool ShowInUI();

  public abstract string GetStatusMessage(ProcessCondition.Status status);

  public string GetStatusMessage() => this.GetStatusMessage(this.EvaluateCondition());

  public abstract string GetStatusTooltip(ProcessCondition.Status status);

  public string GetStatusTooltip() => this.GetStatusTooltip(this.EvaluateCondition());

  public virtual StatusItem GetStatusItem(ProcessCondition.Status status) => (StatusItem) null;

  public virtual ProcessCondition GetParentCondition() => this.parentCondition;

  public enum ProcessConditionType
  {
    RocketFlight,
    RocketPrep,
    RocketStorage,
    RocketBoard,
    All,
  }

  public enum Status
  {
    Failure,
    Warning,
    Ready,
  }
}

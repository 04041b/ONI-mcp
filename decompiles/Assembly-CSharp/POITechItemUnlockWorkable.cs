// Decompiled with JetBrains decompiler
// Type: POITechItemUnlockWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class POITechItemUnlockWorkable : Workable
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.ResearchingFromPOI;
    this.alwaysShowProgressBar = true;
    this.resetProgressOnStop = false;
    this.synchronizeAnims = true;
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    base.OnCompleteWork(worker);
    POITechItemUnlocks.Instance smi = this.GetSMI<POITechItemUnlocks.Instance>();
    smi.UnlockTechItems();
    smi.sm.pendingChore.Set(false, smi);
    this.gameObject.Trigger(1980521255);
    Prioritizable.RemoveRef(this.gameObject);
  }
}

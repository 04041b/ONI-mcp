// Decompiled with JetBrains decompiler
// Type: RemoteWorker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public class RemoteWorker : StandardWorker
{
  [MyCmpGet]
  private RemoteWorkerSM remoteWorkerSM;

  public override Attributes GetAttributes()
  {
    WorkerBase workerBase = this.remoteWorkerSM.HomeDepot?.GetActiveTerminalWorker() ?? (WorkerBase) null;
    return (Object) workerBase != (Object) null ? workerBase.GetAttributes() : (Attributes) null;
  }

  public override AttributeConverterInstance GetAttributeConverter(string id)
  {
    WorkerBase workerBase = this.remoteWorkerSM.HomeDepot?.GetActiveTerminalWorker() ?? (WorkerBase) null;
    return (Object) workerBase != (Object) null ? workerBase.GetAttributeConverter(id) : (AttributeConverterInstance) null;
  }

  protected override void TryPlayingIdle()
  {
    if (this.remoteWorkerSM.Docked)
      this.GetComponent<KAnimControllerBase>().Play((HashedString) "in_dock_idle");
    else
      base.TryPlayingIdle();
  }

  protected override void InternalStopWork(Workable target_workable, bool is_aborted)
  {
    base.InternalStopWork(target_workable, is_aborted);
    Vector3 position = this.transform.GetPosition();
    ref Vector3 local = ref position;
    RemoteWorkerSM remoteWorkerSm = this.remoteWorkerSM;
    double layerZ = (double) Grid.GetLayerZ((remoteWorkerSm != null ? (remoteWorkerSm.Docked ? 1 : 0) : 0) != 0 ? Grid.SceneLayer.BuildingUse : Grid.SceneLayer.Move);
    local.z = (float) layerZ;
    this.transform.SetPosition(position);
  }
}

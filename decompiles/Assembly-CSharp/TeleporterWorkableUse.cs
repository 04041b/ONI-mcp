// Decompiled with JetBrains decompiler
// Type: TeleporterWorkableUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class TeleporterWorkableUse : Workable
{
  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(5f);
    this.resetProgressOnStop = true;
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    Teleporter component = this.GetComponent<Teleporter>();
    Teleporter teleportTarget = component.FindTeleportTarget();
    component.SetTeleportTarget(teleportTarget);
    TeleportalPad.StatesInstance smi = teleportTarget.GetSMI<TeleportalPad.StatesInstance>();
    smi.sm.targetTeleporter.Trigger(smi);
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    TeleportalPad.StatesInstance smi = this.GetSMI<TeleportalPad.StatesInstance>();
    smi.sm.doTeleport.Trigger(smi);
  }
}

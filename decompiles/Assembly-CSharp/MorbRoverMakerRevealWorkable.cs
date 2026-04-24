// Decompiled with JetBrains decompiler
// Type: MorbRoverMakerRevealWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MorbRoverMakerRevealWorkable : Workable
{
  public const string WORKABLE_PRE_ANIM_NAME = "reveal_working_pre";
  public const string WORKABLE_LOOP_ANIM_NAME = "reveal_working_loop";
  public const string WORKABLE_PST_ANIM_NAME = "reveal_working_pst";

  protected override void OnPrefabInit()
  {
    this.workAnims = new HashedString[2]
    {
      (HashedString) "reveal_working_pre",
      (HashedString) "reveal_working_loop"
    };
    this.workingPstComplete = new HashedString[1]
    {
      (HashedString) "reveal_working_pst"
    };
    this.workingPstFailed = new HashedString[1]
    {
      (HashedString) "reveal_working_pst"
    };
    base.OnPrefabInit();
    this.workingStatusItem = Db.Get().BuildingStatusItems.MorbRoverMakerBuildingRevealed;
    this.SetWorkerStatusItem(Db.Get().DuplicantStatusItems.MorbRoverMakerWorkingOnRevealing);
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_gravitas_morb_tank_kanim")
    };
    this.lightEfficiencyBonus = true;
    this.synchronizeAnims = true;
    this.SetWorkTime(15f);
  }

  protected override void OnStartWork(WorkerBase worker) => base.OnStartWork(worker);
}

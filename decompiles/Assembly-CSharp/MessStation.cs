// Decompiled with JetBrains decompiler
// Type: MessStation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/MessStation")]
public class MessStation : Workable, IDiningSeat
{
  public static readonly Descriptor TABLE_SALT_DESCRIPTOR = new Descriptor(string.Format((string) UI.BUILDINGEFFECTS.MESS_TABLE_SALT, (object) TableSaltTuning.MORALE_MODIFIER), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.MESS_TABLE_SALT, (object) TableSaltTuning.MORALE_MODIFIER));
  [MyCmpGet]
  private Ownable ownable;
  private MessStation.MessStationSM.Instance smi;
  public static readonly HashedString eatAnim = (HashedString) "anim_eat_table_kanim";
  public static readonly HashedString reloadElectrobankAnim = (HashedString) "anim_bionic_eat_table_kanim";

  protected override void OnPrefabInit()
  {
    this.ownable.AddAssignPrecondition(new Func<MinionAssignablesProxy, bool>(this.HasCaloriesOwnablePrecondition));
    base.OnPrefabInit();
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim(MessStation.eatAnim)
    };
  }

  public static bool CanBeAssignedTo(IAssignableIdentity assignee)
  {
    MinionAssignablesProxy assignablesProxy = assignee as MinionAssignablesProxy;
    if ((UnityEngine.Object) assignablesProxy == (UnityEngine.Object) null)
      return false;
    MinionIdentity target = assignablesProxy.target as MinionIdentity;
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
      return false;
    if (Db.Get().Amounts.Calories.Lookup((Component) target) != null)
      return true;
    return Game.IsDlcActiveForCurrentSave("DLC3_ID") && target.model == BionicMinionConfig.MODEL;
  }

  private bool HasCaloriesOwnablePrecondition(MinionAssignablesProxy worker)
  {
    return MessStation.CanBeAssignedTo((IAssignableIdentity) worker);
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    worker.GetWorkable().GetComponent<Edible>().CompleteWork(worker);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi = new MessStation.MessStationSM.Instance(this);
    this.smi.StartSM();
  }

  public override List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    if (go.GetComponent<Storage>().Has(TableSaltConfig.ID.ToTag()))
      descriptors.Add(MessStation.TABLE_SALT_DESCRIPTOR);
    return descriptors;
  }

  public bool HasSalt => this.smi.HasSalt;

  public HashedString EatAnim => MessStation.eatAnim;

  public HashedString ReloadElectrobankAnim => MessStation.reloadElectrobankAnim;

  public Storage FindStorage() => this.GetComponent<Storage>();

  public Operational FindOperational() => this.GetComponent<Operational>();

  public KPrefabID Diner { get; set; }

  public class MessStationSM : 
    GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation>
  {
    public MessStation.MessStationSM.SaltState salt;
    public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State eating;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.salt.none;
      this.salt.none.Transition(this.salt.salty, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => smi.HasSalt)).PlayAnim("off");
      this.salt.salty.Transition(this.salt.none, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => !smi.HasSalt)).PlayAnim("salt").EventTransition(GameHashes.EatStart, this.eating);
      this.eating.Transition(this.salt.salty, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => smi.HasSalt && !smi.IsEating())).Transition(this.salt.none, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => !smi.HasSalt && !smi.IsEating())).PlayAnim("off");
    }

    public class SaltState : 
      GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State
    {
      public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State none;
      public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State salty;
    }

    public new class Instance : 
      GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.GameInstance
    {
      private Storage saltStorage;
      private Reservable reservable;

      public Instance(MessStation master)
        : base(master)
      {
        this.saltStorage = master.GetComponent<Storage>();
        this.reservable = master.GetComponent<Reservable>();
      }

      public bool HasSalt => this.saltStorage.Has(TableSaltConfig.ID.ToTag());

      public bool IsEating()
      {
        ChoreDriver component;
        if ((UnityEngine.Object) this.reservable == (UnityEngine.Object) null || (UnityEngine.Object) this.reservable.ReservedBy == (UnityEngine.Object) null || !this.reservable.ReservedBy.TryGetComponent<ChoreDriver>(out component) || !component.HasChore())
          return false;
        return component.GetCurrentChore() is ReloadElectrobankChore currentChore ? currentChore.IsInstallingAtMessStation() : component.GetCurrentChore().choreType.urge == Db.Get().Urges.Eat;
      }
    }
  }
}

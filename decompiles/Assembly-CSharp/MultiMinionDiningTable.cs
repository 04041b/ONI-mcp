// Decompiled with JetBrains decompiler
// Type: MultiMinionDiningTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class MultiMinionDiningTable : KMonoBehaviour, IGameObjectEffectDescriptor
{
  public const string SEAT_ID = "MultiMinionDiningSeat";
  [MyCmpGet]
  private readonly Storage storage;
  private static readonly HashedString ANIM = (HashedString) "salt";
  [MyCmpReq]
  private readonly KAnimControllerBase animController;
  private readonly Dictionary<GameObject, MultiMinionDiningTable.Diner> communalDiners = new Dictionary<GameObject, MultiMinionDiningTable.Diner>();
  private static readonly HashedString COMMUNAL_DINING_EFFECT = (HashedString) "CommunalDining";
  private const int MORALE_MODIFIER = 1;
  private static readonly Descriptor COMMUNAL_DINING_DESCRIPTOR = new Descriptor(string.Format((string) UI.BUILDINGEFFECTS.COMMUNAL_DINING, (object) 1), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.COMMUNAL_DINING, (object) 1));

  public static int SeatCount => MultiMinionDiningTableConfig.SeatCount;

  public bool HasSalt
  {
    get
    {
      return (UnityEngine.Object) this.storage != (UnityEngine.Object) null && (double) this.storage.GetMassAvailable(TableSaltConfig.TAG) >= (double) TableSaltTuning.CONSUMABLE_RATE;
    }
  }

  private static GameObject SpawnSeat(
    MultiMinionDiningTable diningTable,
    int diningTableCell,
    int seatIndex)
  {
    GameObject go = Util.KInstantiate(Assets.GetPrefab((Tag) ApproachableLocator.ID), diningTable.transform.gameObject, "MultiMinionDiningSeat");
    go.transform.SetPosition(Grid.CellToPosCBC(Grid.OffsetCell(diningTableCell, MultiMinionDiningTableConfig.seats[seatIndex].TableRelativeLocation), Grid.SceneLayer.Move));
    go.SetActive(true);
    go.AddOrGet<MultiMinionDiningTable.Seat>().Initialize(seatIndex);
    go.AddOrGet<Reservable>();
    go.GetComponent<KPrefabID>().CopyTags(diningTable.GetComponent<KPrefabID>());
    return go;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    int cell = Grid.PosToCell((KMonoBehaviour) this);
    for (int seatIndex = 0; seatIndex < MultiMinionDiningTable.SeatCount; ++seatIndex)
      MultiMinionDiningTable.SpawnSeat(this, cell, seatIndex);
    this.animController.Play(MultiMinionDiningTable.ANIM);
    this.UpdateSaltVisibility();
    this.storage.Subscribe(-1697596308, (Action<object>) (_ => this.UpdateSaltVisibility()));
  }

  public void UpdateSaltVisibility()
  {
    if (this.HasSalt)
    {
      foreach (MultiMinionDiningTable.Seat componentsInChild in this.gameObject.GetComponentsInChildren<MultiMinionDiningTable.Seat>())
      {
        bool is_visible = !componentsInChild.HasDiner;
        this.animController.SetSymbolVisiblity((KAnimHashedString) componentsInChild.SaltSymbol, is_visible);
      }
    }
    else
    {
      foreach (MultiMinionDiningTable.Seat componentsInChild in this.gameObject.GetComponentsInChildren<MultiMinionDiningTable.Seat>())
        this.animController.SetSymbolVisiblity((KAnimHashedString) componentsInChild.SaltSymbol, false);
    }
  }

  private void RegisterCommunalDiner(KPrefabID diner)
  {
    Effects component;
    if (diner.TryGetComponent<Effects>(out component))
      component.Add(MultiMinionDiningTable.COMMUNAL_DINING_EFFECT, true);
    else
      Debug.LogWarning((object) "Diner has no Effects component");
    this.communalDiners[diner.gameObject] = new MultiMinionDiningTable.Diner(this, diner);
  }

  private void UnregisterCommunalDiner(KPrefabID dinerKpid)
  {
    MultiMinionDiningTable.Diner diner;
    if (!this.communalDiners.TryGetValue(dinerKpid.gameObject, out diner))
      return;
    diner.CleanUp();
    this.communalDiners.Remove(dinerKpid.gameObject);
  }

  private void OnDinerStartTalking(KPrefabID diner, object untypedStartTalkingEvent)
  {
    KPrefabID component;
    if (!(untypedStartTalkingEvent is ConversationManager.StartedTalkingEvent startedTalkingEvent) || !startedTalkingEvent.talker.TryGetComponent<KPrefabID>(out component) || (UnityEngine.Object) component != (UnityEngine.Object) diner)
      return;
    diner.AddTag(GameTags.WantsToTalk);
    diner.AddTag(GameTags.DoNotInterruptMe);
  }

  private void OnDinerStopTalking(KPrefabID diner, object untypedStoppedTalker)
  {
    KPrefabID component;
    if (!(untypedStoppedTalker is GameObject gameObject) || !gameObject.TryGetComponent<KPrefabID>(out component) || (UnityEngine.Object) component != (UnityEngine.Object) diner)
      return;
    diner.RemoveTag(GameTags.WantsToTalk);
  }

  private void OnDinerChanged(KPrefabID prevDiner, KPrefabID newDiner, int seatIndex)
  {
    MultiMinionDiningTable.Seat[] componentsInChildren = this.gameObject.GetComponentsInChildren<MultiMinionDiningTable.Seat>();
    bool is_visible = (UnityEngine.Object) newDiner == (UnityEngine.Object) null && this.HasSalt;
    this.animController.SetSymbolVisiblity((KAnimHashedString) componentsInChildren[seatIndex].SaltSymbol, is_visible);
    if ((UnityEngine.Object) prevDiner != (UnityEngine.Object) null && this.communalDiners.ContainsKey(prevDiner.gameObject))
      this.UnregisterCommunalDiner(prevDiner);
    if ((UnityEngine.Object) newDiner != (UnityEngine.Object) null)
    {
      int num = 0;
      foreach (MultiMinionDiningTable.Seat seat in componentsInChildren)
      {
        if (seat.HasDiner)
        {
          ++num;
          if (num > 1)
            break;
        }
      }
      if (num <= 1)
        return;
      foreach (MultiMinionDiningTable.Seat seat in componentsInChildren)
      {
        if (!((UnityEngine.Object) seat.Diner == (UnityEngine.Object) null) && !this.communalDiners.ContainsKey(seat.Diner.gameObject))
          this.RegisterCommunalDiner(seat.Diner);
      }
    }
    else
    {
      if (this.communalDiners.Count != 1)
        return;
      foreach (MultiMinionDiningTable.Seat seat in componentsInChildren)
      {
        if (!((UnityEngine.Object) seat.Diner == (UnityEngine.Object) null))
          this.UnregisterCommunalDiner(seat.Diner);
      }
    }
  }

  List<Descriptor> IGameObjectEffectDescriptor.GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>()
    {
      MultiMinionDiningTable.COMMUNAL_DINING_DESCRIPTOR
    };
    if (this.HasSalt)
      descriptors.Add(MessStation.TABLE_SALT_DESCRIPTOR);
    return descriptors;
  }

  public class Seat : Assignable, IDiningSeat
  {
    private int index;
    private KPrefabID diner;

    private MultiMinionDiningTableConfig.Seat SeatConfig
    {
      get => MultiMinionDiningTableConfig.seats[this.index];
    }

    public HashedString SaltSymbol => this.SeatConfig.SaltSymbol;

    public GameObject DiningTable => this.transform.parent.gameObject;

    public bool HasSalt => this.DiningTable.GetComponent<MultiMinionDiningTable>().HasSalt;

    public HashedString EatAnim => this.SeatConfig.EatAnim;

    public HashedString ReloadElectrobankAnim => this.SeatConfig.ReloadElectrobankAnim;

    public Storage FindStorage() => this.DiningTable.GetComponent<Storage>();

    public Operational FindOperational() => this.DiningTable.GetComponent<Operational>();

    public KPrefabID Diner
    {
      get => this.diner;
      set
      {
        KPrefabID diner = this.diner;
        this.diner = value;
        this.DiningTable.GetComponent<MultiMinionDiningTable>().OnDinerChanged(diner, this.diner, this.index);
      }
    }

    public bool HasDiner => (UnityEngine.Object) this.Diner != (UnityEngine.Object) null;

    public Seat()
    {
      this.slotID = Db.Get().AssignableSlots.MessStation.Id;
      this.canBePublic = true;
    }

    public void Initialize(int index) => this.index = index;
  }

  private readonly struct Diner
  {
    private readonly KPrefabID kpid;
    private readonly int startTalkingHandler;
    private readonly int stopTalkingHandler;

    public Diner(MultiMinionDiningTable table, KPrefabID diner)
    {
      this.kpid = diner;
      diner.AddTag(GameTags.CommunalDining);
      diner.AddTag(GameTags.AlwaysConverse);
      this.startTalkingHandler = diner.Subscribe(-594200555, (Action<object>) (eventData => table.OnDinerStartTalking(diner, eventData)));
      this.stopTalkingHandler = diner.Subscribe(25860745, (Action<object>) (eventData => table.OnDinerStopTalking(diner, eventData)));
    }

    public void CleanUp()
    {
      this.kpid.RemoveTag(GameTags.CommunalDining);
      this.kpid.RemoveTag(GameTags.AlwaysConverse);
      this.kpid.Unsubscribe(this.startTalkingHandler);
      this.kpid.Unsubscribe(this.stopTalkingHandler);
    }
  }
}

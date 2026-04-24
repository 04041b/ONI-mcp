// Decompiled with JetBrains decompiler
// Type: ParkSign
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ParkSign")]
public class ParkSign : KMonoBehaviour
{
  private static readonly EventSystem.IntraObjectHandler<ParkSign> TriggerRoomEffectsDelegate = new EventSystem.IntraObjectHandler<ParkSign>((Action<ParkSign, object>) ((component, data) => component.TriggerRoomEffects(data)));

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<ParkSign>(-832141045, ParkSign.TriggerRoomEffectsDelegate);
  }

  private void TriggerRoomEffects(object data)
  {
    GameObject gameObject = (GameObject) data;
    Game.Instance.roomProber.GetRoomOfGameObject(this.gameObject)?.roomType.TriggerRoomEffects(this.gameObject.GetComponent<KPrefabID>(), gameObject.GetComponent<Effects>());
  }
}

// Decompiled with JetBrains decompiler
// Type: Reservable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/Reservable")]
public class Reservable : KMonoBehaviour
{
  private GameObject reservedBy;

  public GameObject ReservedBy => this.reservedBy;

  public bool IsReserved => (Object) this.reservedBy != (Object) null;

  public bool Reserve(GameObject reserver)
  {
    if (!((Object) this.reservedBy == (Object) null))
      return false;
    this.reservedBy = reserver;
    return true;
  }

  public void ClearReservation() => this.reservedBy = (GameObject) null;

  public bool IsReservableBy(GameObject reserver)
  {
    return (Object) this.reservedBy == (Object) null || (Object) this.reservedBy == (Object) reserver;
  }
}

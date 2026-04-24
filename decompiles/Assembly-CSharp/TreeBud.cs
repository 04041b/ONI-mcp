// Decompiled with JetBrains decompiler
// Type: TreeBud
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/TreeBud")]
public class TreeBud : KMonoBehaviour
{
  [Serialize]
  public Ref<BuddingTrunk> buddingTrunk;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    PlantBranch.Instance smi = this.gameObject.GetSMI<PlantBranch.Instance>();
    if (smi == null || smi.IsRunning())
      return;
    smi.StartSM();
  }

  public BuddingTrunk GetAndForgetOldTrunk()
  {
    BuddingTrunk andForgetOldTrunk = this.buddingTrunk == null ? (BuddingTrunk) null : this.buddingTrunk.Get();
    this.buddingTrunk = (Ref<BuddingTrunk>) null;
    return andForgetOldTrunk;
  }
}

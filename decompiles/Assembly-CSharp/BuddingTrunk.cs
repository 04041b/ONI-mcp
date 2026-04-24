// Decompiled with JetBrains decompiler
// Type: BuddingTrunk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/BuddingTrunk")]
public class BuddingTrunk : KMonoBehaviour
{
  [Serialize]
  private Ref<HarvestDesignatable>[] buds;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    PlantBranchGrower.Instance smi = this.gameObject.GetSMI<PlantBranchGrower.Instance>();
    if (smi == null || smi.IsRunning())
      return;
    smi.StartSM();
  }

  public KPrefabID[] GetAndForgetOldSerializedBranches()
  {
    KPrefabID[] serializedBranches = (KPrefabID[]) null;
    if (this.buds != null)
    {
      serializedBranches = new KPrefabID[this.buds.Length];
      for (int index = 0; index < this.buds.Length; ++index)
      {
        HarvestDesignatable harvestDesignatable = this.buds[index] == null ? (HarvestDesignatable) null : this.buds[index].Get();
        serializedBranches[index] = (Object) harvestDesignatable == (Object) null ? (KPrefabID) null : harvestDesignatable.GetComponent<KPrefabID>();
      }
    }
    this.buds = (Ref<HarvestDesignatable>[]) null;
    return serializedBranches;
  }
}

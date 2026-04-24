// Decompiled with JetBrains decompiler
// Type: RocketProcessConditionDisplayTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class RocketProcessConditionDisplayTarget : KMonoBehaviour, IProcessConditionSet, ISim1000ms
{
  private CraftModuleInterface craftModuleInterface;
  [MyCmpReq]
  private KSelectable kselectable;
  private Guid statusHandle = Guid.Empty;

  public List<ProcessCondition> GetConditionSet(
    ProcessCondition.ProcessConditionType conditionType)
  {
    if ((UnityEngine.Object) this.craftModuleInterface == (UnityEngine.Object) null)
      this.craftModuleInterface = this.GetComponent<RocketModuleCluster>().CraftInterface;
    return this.craftModuleInterface.GetConditionSet(conditionType);
  }

  public int PopulateConditionSet(
    ProcessCondition.ProcessConditionType conditionType,
    List<ProcessCondition> conditions)
  {
    if ((UnityEngine.Object) this.craftModuleInterface == (UnityEngine.Object) null)
      this.craftModuleInterface = this.GetComponent<RocketModuleCluster>().CraftInterface;
    return this.craftModuleInterface.PopulateConditionSet(conditionType, conditions);
  }

  public void Sim1000ms(float dt)
  {
    bool flag = false;
    List<ProcessCondition> v;
    using (ProcessCondition.ListPool.Get(out v))
    {
      this.PopulateConditionSet(ProcessCondition.ProcessConditionType.All, v);
      foreach (ProcessCondition processCondition in v)
      {
        if (processCondition.EvaluateCondition() == ProcessCondition.Status.Failure)
        {
          flag = true;
          if (this.statusHandle == Guid.Empty)
          {
            this.statusHandle = this.kselectable.AddStatusItem(Db.Get().BuildingStatusItems.RocketChecklistIncomplete);
            break;
          }
          break;
        }
      }
    }
    if (flag || !(this.statusHandle != Guid.Empty))
      return;
    this.kselectable.RemoveStatusItem(this.statusHandle);
  }
}

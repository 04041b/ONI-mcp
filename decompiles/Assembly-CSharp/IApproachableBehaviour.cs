// Decompiled with JetBrains decompiler
// Type: IApproachableBehaviour
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public interface IApproachableBehaviour
{
  bool IsValidTarget();

  GameObject GetTarget();

  StatusItem GetApproachStatusItem();

  StatusItem GetBehaviourStatusItem();

  CellOffset[] GetApproachOffsets() => OffsetGroups.Use;

  void OnArrive()
  {
  }

  void OnSuccess()
  {
  }

  void OnFailure()
  {
  }
}

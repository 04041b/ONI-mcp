// Decompiled with JetBrains decompiler
// Type: IStorage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public interface IStorage
{
  bool ShouldShowInUI();

  bool allowUIItemRemoval { get; set; }

  GameObject Drop(GameObject go, bool do_disease_transfer = true);

  List<GameObject> GetItems();

  bool IsFull();

  bool IsEmpty();

  float Capacity();

  float RemainingCapacity();

  float GetAmountAvailable(Tag tag);

  void ConsumeIgnoringDisease(Tag tag, float amount);
}

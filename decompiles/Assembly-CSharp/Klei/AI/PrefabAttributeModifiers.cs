// Decompiled with JetBrains decompiler
// Type: Klei.AI.PrefabAttributeModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Klei.AI;

[AddComponentMenu("KMonoBehaviour/scripts/PrefabAttributeModifiers")]
public class PrefabAttributeModifiers : KMonoBehaviour
{
  public List<AttributeModifier> descriptors = new List<AttributeModifier>();

  protected override void OnPrefabInit() => base.OnPrefabInit();

  public void AddAttributeDescriptor(AttributeModifier modifier) => this.descriptors.Add(modifier);

  public void RemovePrefabAttribute(AttributeModifier modifier)
  {
    this.descriptors.Remove(modifier);
  }
}

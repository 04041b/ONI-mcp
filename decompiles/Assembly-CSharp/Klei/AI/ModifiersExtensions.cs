// Decompiled with JetBrains decompiler
// Type: Klei.AI.ModifiersExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Klei.AI;

public static class ModifiersExtensions
{
  public static Attributes GetAttributes(this KMonoBehaviour cmp) => cmp.gameObject.GetAttributes();

  public static Attributes GetAttributes(this GameObject go)
  {
    Modifiers component = go.GetComponent<Modifiers>();
    return (Object) component != (Object) null ? component.attributes : (Attributes) null;
  }

  public static Amounts GetAmounts(this KMonoBehaviour cmp)
  {
    return cmp is Modifiers ? ((Modifiers) cmp).amounts : cmp.gameObject.GetAmounts();
  }

  public static Amounts GetAmounts(this GameObject go)
  {
    Modifiers component = go.GetComponent<Modifiers>();
    return (Object) component != (Object) null ? component.amounts : (Amounts) null;
  }

  public static Sicknesses GetSicknesses(this KMonoBehaviour cmp) => cmp.gameObject.GetSicknesses();

  public static Sicknesses GetSicknesses(this GameObject go)
  {
    Modifiers component = go.GetComponent<Modifiers>();
    return (Object) component != (Object) null ? component.sicknesses : (Sicknesses) null;
  }
}

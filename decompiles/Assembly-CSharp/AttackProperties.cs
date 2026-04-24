// Decompiled with JetBrains decompiler
// Type: AttackProperties
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
[Serializable]
public class AttackProperties
{
  public Weapon attacker;
  public AttackProperties.DamageType damageType;
  public AttackProperties.TargetType targetType;
  public float base_damage_min;
  public float base_damage_max;
  public int maxHits;
  public float aoe_radius = 2f;
  public List<AttackEffect> effects;

  public enum DamageType
  {
    Standard,
  }

  public enum TargetType
  {
    Single,
    AreaOfEffect,
  }
}

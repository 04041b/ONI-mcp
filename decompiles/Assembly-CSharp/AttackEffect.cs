// Decompiled with JetBrains decompiler
// Type: AttackEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class AttackEffect
{
  public string effectID;
  public float effectProbability;

  public AttackEffect(string ID, float probability)
  {
    this.effectID = ID;
    this.effectProbability = probability;
  }
}

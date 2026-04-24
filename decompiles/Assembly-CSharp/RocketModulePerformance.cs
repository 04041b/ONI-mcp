// Decompiled with JetBrains decompiler
// Type: RocketModulePerformance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public class RocketModulePerformance
{
  public float burden;
  public float fuelKilogramPerDistance;
  public float enginePower;

  public RocketModulePerformance(float burden, float fuelKilogramPerDistance, float enginePower)
  {
    this.burden = burden;
    this.fuelKilogramPerDistance = fuelKilogramPerDistance;
    this.enginePower = enginePower;
  }

  public float Burden => this.burden;

  public float FuelKilogramPerDistance => this.fuelKilogramPerDistance;

  public float EnginePower => this.enginePower;
}

// Decompiled with JetBrains decompiler
// Type: DevGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DevGenerator : Generator
{
  public float wattageRating = 100000f;

  public override void EnergySim200ms(float dt)
  {
    base.EnergySim200ms(dt);
    ushort circuitId = this.CircuitID;
    this.operational.SetFlag(Generator.wireConnectedFlag, circuitId != ushort.MaxValue);
    if (!this.operational.IsOperational)
      return;
    float wattageRating = this.wattageRating;
    if ((double) wattageRating <= 0.0)
      return;
    this.GenerateJoules(Mathf.Max(wattageRating * dt, 1f * dt));
  }
}

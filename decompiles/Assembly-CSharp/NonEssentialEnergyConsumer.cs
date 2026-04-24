// Decompiled with JetBrains decompiler
// Type: NonEssentialEnergyConsumer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class NonEssentialEnergyConsumer : EnergyConsumer
{
  public Action<bool> PoweredStateChanged;
  private bool isPowered;

  public override bool IsPowered
  {
    get => this.isPowered;
    protected set
    {
      if (value == this.isPowered)
        return;
      this.isPowered = value;
      Action<bool> poweredStateChanged = this.PoweredStateChanged;
      if (poweredStateChanged == null)
        return;
      poweredStateChanged(this.isPowered);
    }
  }
}

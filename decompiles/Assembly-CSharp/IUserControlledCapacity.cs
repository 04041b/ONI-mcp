// Decompiled with JetBrains decompiler
// Type: IUserControlledCapacity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IUserControlledCapacity
{
  float UserMaxCapacity { get; set; }

  float AmountStored { get; }

  float MinCapacity { get; }

  float MaxCapacity { get; }

  bool WholeValues { get; }

  bool ControlEnabled() => true;

  LocString CapacityUnits { get; }
}

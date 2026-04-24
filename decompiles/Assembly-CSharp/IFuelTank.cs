// Decompiled with JetBrains decompiler
// Type: IFuelTank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IFuelTank
{
  IStorage Storage { get; }

  bool ConsumeFuelOnLand { get; }

  void DEBUG_FillTank();
}

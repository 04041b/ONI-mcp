// Decompiled with JetBrains decompiler
// Type: IDiningSeat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IDiningSeat
{
  bool HasSalt { get; }

  HashedString EatAnim { get; }

  HashedString ReloadElectrobankAnim { get; }

  Storage FindStorage();

  Operational FindOperational();

  KPrefabID Diner { get; set; }
}

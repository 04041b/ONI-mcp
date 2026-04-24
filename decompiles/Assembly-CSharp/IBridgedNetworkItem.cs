// Decompiled with JetBrains decompiler
// Type: IBridgedNetworkItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public interface IBridgedNetworkItem
{
  void AddNetworks(ICollection<UtilityNetwork> networks);

  bool IsConnectedToNetworks(ICollection<UtilityNetwork> networks);

  int GetNetworkCell();
}

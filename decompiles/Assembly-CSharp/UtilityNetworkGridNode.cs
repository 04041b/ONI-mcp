// Decompiled with JetBrains decompiler
// Type: UtilityNetworkGridNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public struct UtilityNetworkGridNode : IEquatable<UtilityNetworkGridNode>
{
  public UtilityConnections connections;
  public int networkIdx;
  public const int InvalidNetworkIdx = -1;

  public bool Equals(UtilityNetworkGridNode other)
  {
    return this.connections == other.connections && this.networkIdx == other.networkIdx;
  }

  public override bool Equals(object obj) => ((UtilityNetworkGridNode) obj).Equals(this);

  public override int GetHashCode() => base.GetHashCode();

  public static bool operator ==(UtilityNetworkGridNode x, UtilityNetworkGridNode y) => x.Equals(y);

  public static bool operator !=(UtilityNetworkGridNode x, UtilityNetworkGridNode y)
  {
    return !x.Equals(y);
  }
}

// Decompiled with JetBrains decompiler
// Type: ConduitSecondaryOutput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ConduitSecondaryOutput")]
public class ConduitSecondaryOutput : KMonoBehaviour, ISecondaryOutput
{
  [SerializeField]
  public ConduitPortInfo portInfo;

  public bool HasSecondaryConduitType(ConduitType type) => this.portInfo.conduitType == type;

  public CellOffset GetSecondaryConduitOffset(ConduitType type)
  {
    return type == this.portInfo.conduitType ? this.portInfo.offset : CellOffset.none;
  }
}

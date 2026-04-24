// Decompiled with JetBrains decompiler
// Type: Approachable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/Approachable")]
public class Approachable : KMonoBehaviour, IApproachable
{
  public CellOffset[] GetOffsets() => OffsetGroups.Use;

  public int GetCell() => Grid.PosToCell((KMonoBehaviour) this);
}

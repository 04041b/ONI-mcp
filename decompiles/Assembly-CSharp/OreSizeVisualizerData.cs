// Decompiled with JetBrains decompiler
// Type: OreSizeVisualizerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public struct OreSizeVisualizerData
{
  public PrimaryElement primaryElement;
  public OreSizeVisualizerComponents.TiersSetType tierSetType;
  public int absorbHandle;
  public int splitFromChunkHandle;

  public OreSizeVisualizerData(GameObject go)
  {
    this.primaryElement = go.GetComponent<PrimaryElement>();
    this.tierSetType = OreSizeVisualizerComponents.TiersSetType.Ores;
    this.absorbHandle = -1;
    this.splitFromChunkHandle = -1;
  }
}

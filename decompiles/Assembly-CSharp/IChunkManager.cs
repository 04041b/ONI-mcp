// Decompiled with JetBrains decompiler
// Type: IChunkManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public interface IChunkManager
{
  SubstanceChunk CreateChunk(
    Element element,
    float mass,
    float temperature,
    byte diseaseIdx,
    int diseaseCount,
    Vector3 position);

  SubstanceChunk CreateChunk(
    SimHashes element_id,
    float mass,
    float temperature,
    byte diseaseIdx,
    int diseaseCount,
    Vector3 position);
}

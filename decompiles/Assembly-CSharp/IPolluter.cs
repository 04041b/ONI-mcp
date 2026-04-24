// Decompiled with JetBrains decompiler
// Type: IPolluter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public interface IPolluter
{
  int GetRadius();

  int GetNoise();

  GameObject GetGameObject();

  void SetAttributes(Vector2 pos, int dB, GameObject go, string name = null);

  string GetName();

  Vector2 GetPosition();

  void Clear();

  void SetSplat(NoiseSplat splat);
}

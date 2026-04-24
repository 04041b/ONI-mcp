// Decompiled with JetBrains decompiler
// Type: SpriteSheet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public struct SpriteSheet
{
  public string name;
  public int numFrames;
  public int numXFrames;
  public Vector2 uvFrameSize;
  public int renderLayer;
  public Material material;
  public Texture2D texture;
}

// Decompiled with JetBrains decompiler
// Type: RangeVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/RangeVisualizer")]
public class RangeVisualizer : KMonoBehaviour
{
  public Vector2I OriginOffset;
  public Vector2I RangeMin;
  public Vector2I RangeMax;
  public Vector2I TexSize = new Vector2I(64 /*0x40*/, 64 /*0x40*/);
  public bool TestLineOfSight = true;
  public bool BlockingTileVisible;
  public Func<int, bool> BlockingVisibleCb;
  public Func<int, bool> BlockingCb = new Func<int, bool>(Grid.IsSolidCell);
  public bool AllowLineOfSightInvalidCells;
}

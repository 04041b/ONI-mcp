// Decompiled with JetBrains decompiler
// Type: AsteroidDescriptor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public struct AsteroidDescriptor(
  string text,
  string tooltip,
  Color associatedColor,
  List<Tuple<string, Color, float>> bands = null,
  string associatedIcon = null)
{
  public string text = text;
  public string tooltip = tooltip;
  public List<Tuple<string, Color, float>> bands = bands;
  public Color associatedColor = associatedColor;
  public string associatedIcon = associatedIcon;
}

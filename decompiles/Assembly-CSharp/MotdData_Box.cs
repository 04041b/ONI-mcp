// Decompiled with JetBrains decompiler
// Type: MotdData_Box
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class MotdData_Box
{
  public string category;
  public string guid;
  public long startTime;
  public long finishTime;
  public string title;
  public string text;
  public string image;
  public string href;
  public Texture2D resolvedImage;
  public bool resolvedImageIsFromDisk;

  public bool ShouldDisplay()
  {
    long unixTimeSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    return unixTimeSeconds >= this.startTime && this.finishTime >= unixTimeSeconds;
  }
}

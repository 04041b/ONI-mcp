// Decompiled with JetBrains decompiler
// Type: SicknessExposureInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public struct SicknessExposureInfo(string id, string infection_source_info)
{
  public string sicknessID = id;
  public string sourceInfo = infection_source_info;
}

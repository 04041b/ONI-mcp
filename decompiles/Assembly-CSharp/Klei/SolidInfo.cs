// Decompiled with JetBrains decompiler
// Type: Klei.SolidInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei;

public struct SolidInfo(int cellIdx, bool isSolid)
{
  public int cellIdx = cellIdx;
  public bool isSolid = isSolid;
}

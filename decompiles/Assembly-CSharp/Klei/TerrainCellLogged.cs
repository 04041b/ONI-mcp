// Decompiled with JetBrains decompiler
// Type: Klei.TerrainCellLogged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ProcGenGame;
using System.Collections.Generic;
using VoronoiTree;

#nullable disable
namespace Klei;

public class TerrainCellLogged : TerrainCell
{
  public TerrainCellLogged()
  {
  }

  public TerrainCellLogged(ProcGen.Map.Cell node, Diagram.Site site, Dictionary<Tag, int> distancesToTags)
    : base(node, site, distancesToTags)
  {
  }

  public override void LogInfo(string evt, string param, float value)
  {
  }
}

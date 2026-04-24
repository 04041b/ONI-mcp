// Decompiled with JetBrains decompiler
// Type: ClusterMapPathDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class ClusterMapPathDrawer : MonoBehaviour
{
  public ClusterMapPath pathPrefab;
  public Transform pathContainer;

  public ClusterMapPath AddPath()
  {
    ClusterMapPath clusterMapPath = UnityEngine.Object.Instantiate<ClusterMapPath>(this.pathPrefab, this.pathContainer);
    clusterMapPath.Init();
    return clusterMapPath;
  }

  public static List<Vector2> GetDrawPathList(Vector2 startLocation, List<AxialI> pathPoints)
  {
    List<Vector2> drawPathList = new List<Vector2>();
    drawPathList.Add(startLocation);
    drawPathList.AddRange(pathPoints.Select<AxialI, Vector2>((Func<AxialI, Vector2>) (point => point.ToWorld2D())));
    return drawPathList;
  }
}

// Decompiled with JetBrains decompiler
// Type: GraphLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (GraphBase))]
[AddComponentMenu("KMonoBehaviour/scripts/GraphLayer")]
public class GraphLayer : KMonoBehaviour
{
  [MyCmpReq]
  private GraphBase graph_base;

  public GraphBase graph
  {
    get
    {
      if ((Object) this.graph_base == (Object) null)
        this.graph_base = this.GetComponent<GraphBase>();
      return this.graph_base;
    }
  }
}

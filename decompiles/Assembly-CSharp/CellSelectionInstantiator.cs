// Decompiled with JetBrains decompiler
// Type: CellSelectionInstantiator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CellSelectionInstantiator : MonoBehaviour
{
  public GameObject CellSelectionPrefab;

  private void Awake()
  {
    GameObject gameObject1 = Util.KInstantiate(this.CellSelectionPrefab, name: "WorldSelectionCollider");
    GameObject gameObject2 = Util.KInstantiate(this.CellSelectionPrefab, name: "WorldSelectionCollider");
    CellSelectionObject component1 = gameObject1.GetComponent<CellSelectionObject>();
    CellSelectionObject component2 = gameObject2.GetComponent<CellSelectionObject>();
    component1.alternateSelectionObject = component2;
    component2.alternateSelectionObject = component1;
  }
}

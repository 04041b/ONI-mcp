// Decompiled with JetBrains decompiler
// Type: DisinfectTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DisinfectTool : DragTool
{
  public static DisinfectTool Instance;

  public static void DestroyInstance() => DisinfectTool.Instance = (DisinfectTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    DisinfectTool.Instance = this;
    this.interceptNumberKeysForPriority = true;
    this.viewMode = OverlayModes.Disease.ID;
  }

  public void Activate() => PlayerController.Instance.ActivateTool((InterfaceTool) this);

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    for (int layer = 0; layer < 45; ++layer)
    {
      GameObject gameObject = Grid.Objects[cell, layer];
      if ((Object) gameObject != (Object) null)
      {
        Disinfectable component = gameObject.GetComponent<Disinfectable>();
        if ((Object) component != (Object) null && component.GetComponent<PrimaryElement>().DiseaseCount > 0)
          component.MarkForDisinfect();
      }
    }
  }
}

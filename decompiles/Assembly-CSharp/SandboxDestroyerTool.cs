// Decompiled with JetBrains decompiler
// Type: SandboxDestroyerTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SandboxDestroyerTool : BrushTool
{
  public static SandboxDestroyerTool instance;

  public static void DestroyInstance()
  {
    SandboxDestroyerTool.instance = (SandboxDestroyerTool) null;
  }

  private SandboxSettings settings => SandboxToolParameterMenu.instance.settings;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    SandboxDestroyerTool.instance = this;
    this.affectFoundation = true;
  }

  protected override string GetDragSound() => "SandboxTool_Delete_Add";

  public void Activate() => PlayerController.Instance.ActivateTool((InterfaceTool) this);

  protected override void OnActivateTool()
  {
    base.OnActivateTool();
    SandboxToolParameterMenu.instance.gameObject.SetActive(true);
    SandboxToolParameterMenu.instance.DisableParameters();
    SandboxToolParameterMenu.instance.brushRadiusSlider.row.SetActive(true);
  }

  protected override void OnDeactivateTool(InterfaceTool new_tool)
  {
    base.OnDeactivateTool(new_tool);
    SandboxToolParameterMenu.instance.gameObject.SetActive(false);
  }

  public override void GetOverlayColorData(out HashSet<ToolMenu.CellColorData> colors)
  {
    colors = new HashSet<ToolMenu.CellColorData>();
    foreach (int cellsInRadiu in this.cellsInRadius)
      colors.Add(new ToolMenu.CellColorData(cellsInRadiu, this.radiusIndicatorColor));
  }

  public override void OnLeftClickDown(Vector3 cursor_pos)
  {
    base.OnLeftClickDown(cursor_pos);
    KFMOD.PlayUISound(GlobalAssets.GetSound("SandboxTool_Delete"));
  }

  protected override void OnPaintCell(int cell, int distFromOrigin)
  {
    base.OnPaintCell(cell, distFromOrigin);
    GameUtil.DestroyCell(cell, CellEventLogger.Instance.SandBoxTool);
  }
}

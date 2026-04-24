// Decompiled with JetBrains decompiler
// Type: Klei.Input.MarkCellDigAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.Actions;
using UnityEngine;

#nullable disable
namespace Klei.Input;

[Action("Mark Cell")]
public class MarkCellDigAction : DigAction
{
  public override void Dig(int cell, int distFromOrigin)
  {
    GameObject gameObject = DigTool.PlaceDig(cell, distFromOrigin);
    if (!((Object) gameObject != (Object) null))
      return;
    Prioritizable component = gameObject.GetComponent<Prioritizable>();
    if (!((Object) component != (Object) null))
      return;
    component.SetMasterPriority(ToolMenu.Instance.PriorityScreen.GetLastSelectedPriority());
  }

  protected override void EntityDig(IDigActionEntity digActionEntity)
  {
    digActionEntity?.MarkForDig();
  }
}

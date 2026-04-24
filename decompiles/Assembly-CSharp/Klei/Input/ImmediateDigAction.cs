// Decompiled with JetBrains decompiler
// Type: Klei.Input.ImmediateDigAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.Actions;

#nullable disable
namespace Klei.Input;

[Action("Immediate")]
public class ImmediateDigAction : DigAction
{
  public override void Dig(int cell, int distFromOrigin)
  {
    if (!Grid.Solid[cell] || Grid.Foundation[cell])
      return;
    SimMessages.Dig(cell);
  }

  protected override void EntityDig(IDigActionEntity digActionEntity) => digActionEntity?.Dig();
}

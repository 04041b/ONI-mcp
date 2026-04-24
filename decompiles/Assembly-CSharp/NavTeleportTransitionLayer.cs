// Decompiled with JetBrains decompiler
// Type: NavTeleportTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class NavTeleportTransitionLayer(Navigator navigator) : TransitionDriver.OverrideLayer(navigator)
{
  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.BeginTransition(navigator, transition);
    if (transition.start != NavType.Teleport)
      return;
    int cell1 = Grid.PosToCell((KMonoBehaviour) navigator);
    int x1;
    int y1;
    Grid.CellToXY(cell1, out x1, out y1);
    int x2 = x1;
    int y2 = y1;
    int cell2;
    if (navigator.NavGrid.teleportTransitions.TryGetValue(cell1, out cell2))
      Grid.CellToXY(cell2, out x2, out y2);
    transition.x = x2 - x1;
    transition.y = y2 - y1;
  }
}

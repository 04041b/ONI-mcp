// Decompiled with JetBrains decompiler
// Type: NavMask
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class NavMask
{
  public virtual bool IsTraversable(
    PathFinder.PotentialPath path,
    int from_cell,
    int cost,
    int transition_id,
    PathFinderAbilities abilities)
  {
    return true;
  }

  public virtual void ApplyTraversalToPath(ref PathFinder.PotentialPath path, int from_cell)
  {
  }
}

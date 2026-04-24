// Decompiled with JetBrains decompiler
// Type: CreaturePathFinderAbilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreaturePathFinderAbilities(Navigator navigator) : PathFinderAbilities(navigator)
{
  public bool canTraverseSubmered;

  protected override void Refresh(Navigator navigator)
  {
    if (PathFinder.IsSubmerged(navigator.cachedCell))
      this.canTraverseSubmered = true;
    else
      this.canTraverseSubmered = Db.Get().Attributes.MaxUnderwaterTravelCost.Lookup((Component) navigator) == null;
  }

  public override bool TraversePath(
    ref PathFinder.PotentialPath path,
    int from_cell,
    NavType from_nav_type,
    int cost,
    int transition_id,
    bool submerged)
  {
    return !submerged || this.canTraverseSubmered;
  }

  public override PathFinderAbilities Clone()
  {
    CreaturePathFinderAbilities pathFinderAbilities = new CreaturePathFinderAbilities(this.navigator);
    pathFinderAbilities.prefabInstanceID = this.prefabInstanceID;
    pathFinderAbilities.canTraverseSubmered = this.canTraverseSubmered;
    return (PathFinderAbilities) pathFinderAbilities;
  }

  public override void RecycleClone()
  {
  }
}

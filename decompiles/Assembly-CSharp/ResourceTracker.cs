// Decompiled with JetBrains decompiler
// Type: ResourceTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ResourceTracker : WorldTracker
{
  public Tag tag { get; private set; }

  public ResourceTracker(int worldID, Tag materialCategoryTag)
    : base(worldID)
  {
    this.tag = materialCategoryTag;
  }

  public override void UpdateData()
  {
    if ((Object) ClusterManager.Instance.GetWorld(this.WorldID).worldInventory == (Object) null)
      return;
    this.AddPoint(ClusterManager.Instance.GetWorld(this.WorldID).worldInventory.GetAmount(this.tag, false));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedMass(value);
}

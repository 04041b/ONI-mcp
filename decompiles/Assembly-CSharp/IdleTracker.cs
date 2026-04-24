// Decompiled with JetBrains decompiler
// Type: IdleTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class IdleTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    this.objectsOfInterest.Clear();
    int num = 0;
    List<MinionIdentity> worldItems = Components.LiveMinionIdentities.GetWorldItems(this.WorldID);
    for (int index = 0; index < worldItems.Count; ++index)
    {
      if (worldItems[index].HasTag(GameTags.Idle))
      {
        ++num;
        this.objectsOfInterest.Add(worldItems[index].gameObject);
      }
    }
    this.AddPoint((float) num);
  }

  public override string FormatValueString(float value) => value.ToString();
}

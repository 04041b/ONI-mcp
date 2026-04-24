// Decompiled with JetBrains decompiler
// Type: CropTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CropTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    foreach (PlantablePlot plantablePlot in Components.PlantablePlots.GetItems(this.WorldID))
    {
      if (!((Object) plantablePlot.plant == (Object) null) && plantablePlot.HasDepositTag(GameTags.CropSeed) && !plantablePlot.plant.HasTag(GameTags.Wilting))
        ++num;
    }
    this.AddPoint(num);
  }

  public override string FormatValueString(float value) => value.ToString() + "%";
}

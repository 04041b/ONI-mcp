// Decompiled with JetBrains decompiler
// Type: WorkingToiletTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class WorkingToiletTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    int num = 0;
    foreach (IUsable usable in Components.Toilets.WorldItemsEnumerate(this.WorldID, true))
    {
      if (usable.IsUsable())
        ++num;
    }
    this.AddPoint((float) num);
  }

  public override string FormatValueString(float value) => value.ToString();
}

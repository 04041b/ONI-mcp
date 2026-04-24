// Decompiled with JetBrains decompiler
// Type: Database.Sicknesses
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
namespace Database;

public class Sicknesses : ResourceSet<Sickness>
{
  public Sickness FoodSickness;
  public Sickness SlimeSickness;
  public Sickness ZombieSickness;
  public Sickness Allergies;
  public Sickness RadiationSickness;
  public Sickness Sunburn;

  public Sicknesses(ResourceSet parent)
    : base(nameof (Sicknesses), parent)
  {
    this.FoodSickness = this.Add((Sickness) new Klei.AI.FoodSickness());
    this.SlimeSickness = this.Add((Sickness) new Klei.AI.SlimeSickness());
    this.ZombieSickness = this.Add((Sickness) new Klei.AI.ZombieSickness());
    if (DlcManager.FeatureRadiationEnabled())
      this.RadiationSickness = this.Add((Sickness) new Klei.AI.RadiationSickness());
    this.Allergies = this.Add((Sickness) new Klei.AI.Allergies());
    this.Sunburn = this.Add((Sickness) new Klei.AI.Sunburn());
  }

  public static bool IsValidID(string id)
  {
    bool flag = false;
    foreach (Resource resource in Db.Get().Sicknesses.resources)
    {
      if (resource.Id == id)
        flag = true;
    }
    return flag;
  }
}

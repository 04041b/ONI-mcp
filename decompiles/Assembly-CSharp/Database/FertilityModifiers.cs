// Decompiled with JetBrains decompiler
// Type: Database.FertilityModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class FertilityModifiers : ResourceSet<FertilityModifier>
{
  public List<FertilityModifier> GetForTag(Tag searchTag)
  {
    List<FertilityModifier> forTag = new List<FertilityModifier>();
    foreach (FertilityModifier resource in this.resources)
    {
      if (resource.TargetTag == searchTag)
        forTag.Add(resource);
    }
    return forTag;
  }
}

// Decompiled with JetBrains decompiler
// Type: Database.MonumentParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class MonumentParts : ResourceSet<MonumentPartResource>
{
  public MonumentParts(ResourceSet parent)
    : base(nameof (MonumentParts), parent)
  {
    this.Initialize();
    foreach (MonumentPartInfo monumentPart in Blueprints.Get().all.monumentParts)
      this.Add(monumentPart.id, monumentPart.name, monumentPart.desc, monumentPart.rarity, monumentPart.animFile, monumentPart.state, monumentPart.symbolName, monumentPart.part, monumentPart.requiredDlcIds, monumentPart.forbiddenDlcIds);
  }

  public void Add(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFilename,
    string state,
    string symbolName,
    MonumentPartResource.Part part,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
  {
    this.resources.Add(new MonumentPartResource(id, name, desc, rarity, animFilename, state, symbolName, part, requiredDlcIds, forbiddenDlcIds));
  }

  public List<MonumentPartResource> GetParts(MonumentPartResource.Part part)
  {
    return this.resources.FindAll((Predicate<MonumentPartResource>) (mpr => mpr.part == part));
  }
}

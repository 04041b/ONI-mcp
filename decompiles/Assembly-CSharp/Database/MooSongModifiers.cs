// Decompiled with JetBrains decompiler
// Type: Database.MooSongModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Database;

public class MooSongModifiers : ResourceSet<MooSongModifier>
{
  public List<MooSongModifier> GetForTag(Tag searchTag)
  {
    List<MooSongModifier> forTag = new List<MooSongModifier>();
    foreach (MooSongModifier resource in this.resources)
    {
      if (resource.TargetTag == searchTag)
        forTag.Add(resource);
    }
    return forTag;
  }
}

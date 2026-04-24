// Decompiled with JetBrains decompiler
// Type: AlgaeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AlgaeConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.Algae;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.CreateSolidOreEntity(this.ElementID, new List<Tag>()
    {
      GameTags.Life
    });
  }
}

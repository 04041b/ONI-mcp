// Decompiled with JetBrains decompiler
// Type: DiseaseVisualization
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DiseaseVisualization : ScriptableObject
{
  public Sprite overlaySprite;
  public List<DiseaseVisualization.Info> info = new List<DiseaseVisualization.Info>();

  public DiseaseVisualization.Info GetInfo(HashedString id)
  {
    foreach (DiseaseVisualization.Info info in this.info)
    {
      if (id == (HashedString) info.name)
        return info;
    }
    return new DiseaseVisualization.Info();
  }

  [Serializable]
  public struct Info(string name)
  {
    public string name = name;
    public string overlayColourName = "germFoodPoisoning";
  }
}

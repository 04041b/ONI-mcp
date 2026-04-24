// Decompiled with JetBrains decompiler
// Type: Klei.ClusterLayoutSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei;

public class ClusterLayoutSave
{
  public string ID;
  public Vector2I version;
  public List<ClusterLayoutSave.World> worlds;
  public Vector2I size;
  public int currentWorldIdx;
  public int numRings;
  public Dictionary<ClusterLayoutSave.POIType, List<AxialI>> poiLocations = new Dictionary<ClusterLayoutSave.POIType, List<AxialI>>();
  public Dictionary<AxialI, string> poiPlacements = new Dictionary<AxialI, string>();

  public ClusterLayoutSave() => this.worlds = new List<ClusterLayoutSave.World>();

  public class World
  {
    public Data data = new Data();
    public string name = string.Empty;
    public bool isDiscovered;
    public List<string> traits = new List<string>();
    public List<string> storyTraits = new List<string>();
    public List<string> seasons = new List<string>();
    public List<string> generatedSubworlds = new List<string>();
  }

  public enum POIType
  {
    TemporalTear,
    ResearchDestination,
  }
}

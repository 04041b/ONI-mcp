// Decompiled with JetBrains decompiler
// Type: Klei.WorldGenSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei;

public class WorldGenSave
{
  public Vector2I version;
  public Data data;
  public string worldID;
  public List<string> traitIDs;
  public List<string> storyTraitIDs;

  public WorldGenSave() => this.data = new Data();
}

// Decompiled with JetBrains decompiler
// Type: ModInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

#nullable disable
[Serializable]
public struct ModInfo
{
  [JsonConverter(typeof (StringEnumConverter))]
  public ModInfo.Source source;
  [JsonConverter(typeof (StringEnumConverter))]
  public ModInfo.ModType type;
  public string assetID;
  public string assetPath;
  public bool enabled;
  public bool markedForDelete;
  public bool markedForUpdate;
  public string description;
  public ulong lastModifiedTime;

  public enum Source
  {
    Local,
    Steam,
    Rail,
  }

  public enum ModType
  {
    WorldGen,
    Scenario,
    Mod,
  }
}

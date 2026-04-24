// Decompiled with JetBrains decompiler
// Type: Klei.SaveFileRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei;

internal class SaveFileRoot
{
  public int WidthInCells;
  public int HeightInCells;
  public Dictionary<string, byte[]> streamed;
  public string clusterID;
  public List<ModInfo> requiredMods;
  public List<KMod.Label> active_mods;

  public SaveFileRoot() => this.streamed = new Dictionary<string, byte[]>();
}

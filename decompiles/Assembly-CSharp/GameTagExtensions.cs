// Decompiled with JetBrains decompiler
// Type: GameTagExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class GameTagExtensions
{
  public static GameObject Prefab(this Tag tag) => Assets.GetPrefab(tag);

  public static string ProperName(this Tag tag) => TagManager.GetProperName(tag);

  public static string ProperNameStripLink(this Tag tag) => TagManager.GetProperName(tag, true);

  public static Tag Create(SimHashes id) => TagManager.Create(id.ToString());

  public static Tag CreateTag(this SimHashes id) => TagManager.Create(id.ToString());
}

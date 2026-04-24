// Decompiled with JetBrains decompiler
// Type: TallowConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TallowConfig : IOreConfig
{
  public const string ID = "Tallow";
  public static readonly Tag TAG = TagManager.Create("Tallow");

  public SimHashes ElementID => SimHashes.Tallow;

  public GameObject CreatePrefab() => EntityTemplates.CreateSolidOreEntity(this.ElementID);
}

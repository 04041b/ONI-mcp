// Decompiled with JetBrains decompiler
// Type: IBlueprintInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public interface IBlueprintInfo : IHasDlcRestrictions
{
  string id { get; set; }

  string name { get; set; }

  string desc { get; set; }

  PermitRarity rarity { get; }

  string animFile { get; set; }
}

// Decompiled with JetBrains decompiler
// Type: EquippableFacadeInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class EquippableFacadeInfo : IBlueprintInfo, IHasDlcRestrictions
{
  private readonly PermitRarity rarity_;
  public string buildOverride;
  public string defID;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity => this.rarity_;

  public string animFile { get; set; }

  public EquippableFacadeInfo(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string defID,
    string buildOverride,
    string animFile,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.rarity_ = rarity;
    this.defID = defID;
    this.buildOverride = buildOverride;
    this.animFile = animFile;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}

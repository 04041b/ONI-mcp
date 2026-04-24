// Decompiled with JetBrains decompiler
// Type: ArtableInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class ArtableInfo : IBlueprintInfo, IHasDlcRestrictions
{
  private readonly PermitRarity rarity_;
  public string anim;
  public int decor_value;
  public bool cheer_on_complete;
  public string status_id;
  public string prefabId;
  public string symbolname;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity => this.rarity_;

  public string animFile { get; set; }

  public ArtableInfo(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFile,
    string anim,
    int decor_value,
    bool cheer_on_complete,
    string status_id,
    string prefabId,
    string symbolname = "",
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.rarity_ = rarity;
    this.animFile = animFile;
    this.anim = anim;
    this.decor_value = decor_value;
    this.cheer_on_complete = cheer_on_complete;
    this.status_id = status_id;
    this.prefabId = prefabId;
    this.symbolname = symbolname;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}

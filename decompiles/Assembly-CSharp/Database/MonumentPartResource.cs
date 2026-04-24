// Decompiled with JetBrains decompiler
// Type: Database.MonumentPartResource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class MonumentPartResource : PermitResource
{
  public MonumentPartResource.Part part;

  public KAnimFile AnimFile { get; private set; }

  public string SymbolName { get; private set; }

  public string State { get; private set; }

  public MonumentPartResource(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFilename,
    string state,
    string symbolName,
    MonumentPartResource.Part part,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
    : base(id, name, desc, PermitCategory.Artwork, rarity, requiredDlcIds, forbiddenDlcIds)
  {
    this.AnimFile = Assets.GetAnim((HashedString) animFilename);
    this.SymbolName = symbolName;
    this.State = state;
    this.part = part;
  }

  public override PermitPresentationInfo GetPermitPresentationInfo()
  {
    PermitPresentationInfo presentationInfo = new PermitPresentationInfo();
    presentationInfo.sprite = Def.GetUISpriteFromMultiObjectAnim(this.AnimFile);
    presentationInfo.SetFacadeForText((string) UI.KLEI_INVENTORY_SCREEN.MONUMENT_PART_FACADE_FOR);
    return presentationInfo;
  }

  public enum Part
  {
    Bottom,
    Middle,
    Top,
  }
}

// Decompiled with JetBrains decompiler
// Type: Database.ArtableStatuses
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class ArtableStatuses : ResourceSet<ArtableStatusItem>
{
  public ArtableStatusItem AwaitingArting;
  public ArtableStatusItem LookingUgly;
  public ArtableStatusItem LookingOkay;
  public ArtableStatusItem LookingGreat;

  public ArtableStatuses(ResourceSet parent)
    : base(nameof (ArtableStatuses), parent)
  {
    this.AwaitingArting = this.Add(nameof (AwaitingArting), ArtableStatuses.ArtableStatusType.AwaitingArting);
    this.LookingUgly = this.Add(nameof (LookingUgly), ArtableStatuses.ArtableStatusType.LookingUgly);
    this.LookingOkay = this.Add(nameof (LookingOkay), ArtableStatuses.ArtableStatusType.LookingOkay);
    this.LookingGreat = this.Add(nameof (LookingGreat), ArtableStatuses.ArtableStatusType.LookingGreat);
  }

  public ArtableStatusItem Add(string id, ArtableStatuses.ArtableStatusType statusType)
  {
    ArtableStatusItem artableStatusItem = new ArtableStatusItem(id, statusType);
    this.resources.Add(artableStatusItem);
    return artableStatusItem;
  }

  public enum ArtableStatusType
  {
    AwaitingArting,
    LookingUgly,
    LookingOkay,
    LookingGreat,
  }
}

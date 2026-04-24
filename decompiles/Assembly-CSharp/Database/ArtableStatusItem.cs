// Decompiled with JetBrains decompiler
// Type: Database.ArtableStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class ArtableStatusItem : StatusItem
{
  public ArtableStatuses.ArtableStatusType StatusType;

  public ArtableStatusItem(string id, ArtableStatuses.ArtableStatusType statusType)
    : base(id, "BUILDING", "", StatusItem.IconType.Info, statusType == ArtableStatuses.ArtableStatusType.AwaitingArting ? NotificationType.BadMinor : NotificationType.Neutral, false, OverlayModes.None.ID)
  {
    this.StatusType = statusType;
  }
}

// Decompiled with JetBrains decompiler
// Type: Database.StatusItems
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
namespace Database;

public class StatusItems(string id, ResourceSet parent) : ResourceSet<StatusItem>(id, parent)
{
  [DebuggerDisplay("{Id}")]
  public class StatusItemInfo : Resource
  {
    public string Type;
    public string Tooltip;
    public bool IsIconTinted;
    public StatusItem.IconType IconType;
    public string Icon;
    public string SoundPath;
    public bool ShouldNotify;
    public float NotificationDelay;
    public NotificationType NotificationType;
    public bool AllowMultiples;
    public string Effect;
    public HashedString Overlay;
    public HashedString SecondOverlay;
  }
}

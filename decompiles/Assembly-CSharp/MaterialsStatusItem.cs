// Decompiled with JetBrains decompiler
// Type: MaterialsStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MaterialsStatusItem(
  string id,
  string prefix,
  string icon,
  StatusItem.IconType icon_type,
  NotificationType notification_type,
  bool allow_multiples,
  HashedString overlay) : StatusItem(id, prefix, icon, icon_type, notification_type, allow_multiples, overlay)
{
}

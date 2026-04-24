// Decompiled with JetBrains decompiler
// Type: DuplicantsLeftMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class DuplicantsLeftMessage : Message
{
  public override string GetSound() => "";

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.NAME;

  public override string GetMessageBody()
  {
    return (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.MESSAGEBODY;
  }

  public override string GetTooltip() => (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.TOOLTIP;
}

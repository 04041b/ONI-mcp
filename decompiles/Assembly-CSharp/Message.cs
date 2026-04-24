// Decompiled with JetBrains decompiler
// Type: Message
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public abstract class Message : ISaveLoadable
{
  public abstract string GetTitle();

  public abstract string GetSound();

  public abstract string GetMessageBody();

  public abstract string GetTooltip();

  public virtual bool ShowDialog() => true;

  public virtual void OnCleanUp()
  {
  }

  public virtual bool IsValid() => true;

  public virtual bool PlayNotificationSound() => true;

  public virtual void OnClick()
  {
  }

  public virtual NotificationType GetMessageType() => NotificationType.Messages;

  public virtual bool ShowDismissButton() => true;
}

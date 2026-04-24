// Decompiled with JetBrains decompiler
// Type: CodexUnlockedMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class CodexUnlockedMessage : Message
{
  private string unlockMessage;
  private string lockId;

  public CodexUnlockedMessage()
  {
  }

  public CodexUnlockedMessage(string lock_id, string unlock_message)
  {
    this.lockId = lock_id;
    this.unlockMessage = unlock_message;
  }

  public string GetLockId() => this.lockId;

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody()
  {
    return UI.CODEX.CODEX_DISCOVERED_MESSAGE.BODY.Replace("{codex}", this.unlockMessage);
  }

  public override string GetTitle() => (string) UI.CODEX.CODEX_DISCOVERED_MESSAGE.TITLE;

  public override string GetTooltip() => this.GetMessageBody();

  public override bool IsValid() => true;
}

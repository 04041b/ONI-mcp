// Decompiled with JetBrains decompiler
// Type: TutorialMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
public class TutorialMessage : GenericMessage, IHasDlcRestrictions
{
  [Serialize]
  public Tutorial.TutorialMessages messageId;
  public string videoClipId;
  public string videoOverlayName;
  public string videoTitleText;
  public string icon;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;

  public TutorialMessage()
  {
  }

  public TutorialMessage(
    Tutorial.TutorialMessages messageId,
    string title,
    string body,
    string tooltip,
    string videoClipId = null,
    string videoOverlayName = null,
    string videoTitleText = null,
    string icon = "",
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
    : base(title, body, tooltip)
  {
    this.messageId = messageId;
    this.videoClipId = videoClipId;
    this.videoOverlayName = videoOverlayName;
    this.videoTitleText = videoTitleText;
    this.icon = icon;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }
}

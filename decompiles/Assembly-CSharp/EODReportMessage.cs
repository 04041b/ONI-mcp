// Decompiled with JetBrains decompiler
// Type: EODReportMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
public class EODReportMessage : Message
{
  [Serialize]
  private int day;
  [Serialize]
  private string title;
  [Serialize]
  private string tooltip;

  public EODReportMessage(string title, string tooltip)
  {
    this.day = GameUtil.GetCurrentCycle();
    this.title = title;
    this.tooltip = tooltip;
  }

  public EODReportMessage()
  {
  }

  public override string GetSound() => (string) null;

  public override string GetMessageBody() => "";

  public override string GetTooltip() => this.tooltip;

  public override string GetTitle() => this.title;

  public void OpenReport() => ManagementMenu.Instance.OpenReports(this.day);

  public override bool ShowDialog() => false;

  public override void OnClick() => this.OpenReport();
}

// Decompiled with JetBrains decompiler
// Type: LoreBearerSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LoreBearerSideScreen : SideScreenContent
{
  public const int DefaultButtonMenuSideScreenSortOrder = 20;
  public KButton button;
  private LoreBearer target;

  public override bool IsValidForTarget(GameObject target)
  {
    return (UnityEngine.Object) target.GetComponent<LoreBearer>() != (UnityEngine.Object) null;
  }

  public override int GetSideScreenSortOrder() => this.target.GetSideScreenSortOrder();

  public override void SetTarget(GameObject new_target)
  {
    if ((UnityEngine.Object) new_target == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "Invalid gameObject received");
    }
    else
    {
      this.target = new_target.GetComponent<LoreBearer>();
      this.Refresh();
    }
  }

  private void Refresh()
  {
    this.button.isInteractable = this.target.SidescreenButtonInteractable();
    this.button.ClearOnClick();
    this.button.onClick += new System.Action(this.target.OnSidescreenButtonPressed);
    this.button.onClick += new System.Action(this.Refresh);
    this.button.GetComponentInChildren<LocText>().SetText(this.target.SidescreenButtonText);
    this.button.GetComponent<ToolTip>().SetSimpleTooltip(this.target.SidescreenButtonTooltip);
  }
}

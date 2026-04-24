// Decompiled with JetBrains decompiler
// Type: FabricatorListScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class FabricatorListScreen : KToggleMenu
{
  private void Refresh()
  {
    List<KToggleMenu.ToggleInfo> toggleInfo = new List<KToggleMenu.ToggleInfo>();
    foreach (Fabricator user_data in Components.Fabricators.Items)
    {
      KSelectable component = user_data.GetComponent<KSelectable>();
      toggleInfo.Add(new KToggleMenu.ToggleInfo(component.GetName(), (object) user_data));
    }
    this.Setup((IList<KToggleMenu.ToggleInfo>) toggleInfo);
  }

  protected override void OnSpawn()
  {
    this.onSelect += new KToggleMenu.OnSelect(this.OnClickFabricator);
  }

  protected override void OnActivate()
  {
    base.OnActivate();
    this.Refresh();
  }

  private void OnClickFabricator(KToggleMenu.ToggleInfo toggle_info)
  {
    Fabricator userData = (Fabricator) toggle_info.userData;
    SelectTool.Instance.Select(userData.GetComponent<KSelectable>());
  }
}

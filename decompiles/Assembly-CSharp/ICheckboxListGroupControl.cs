// Decompiled with JetBrains decompiler
// Type: ICheckboxListGroupControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public interface ICheckboxListGroupControl
{
  string Title { get; }

  string Description { get; }

  ICheckboxListGroupControl.ListGroup[] GetData();

  bool SidescreenEnabled();

  int CheckboxSideScreenSortOrder();

  struct ListGroup(
    string title,
    ICheckboxListGroupControl.CheckboxItem[] checkboxItems,
    Func<string, string> resolveTitleCallback = null,
    System.Action onItemClicked = null)
  {
    public Func<string, string> resolveTitleCallback = resolveTitleCallback;
    public System.Action onItemClicked = onItemClicked;
    public string title = title;
    public ICheckboxListGroupControl.CheckboxItem[] checkboxItems = checkboxItems;
  }

  struct CheckboxItem
  {
    public string text;
    public string tooltip;
    public bool isOn;
    public Func<string, bool> overrideLinkActions;
    public Func<string, object, string> resolveTooltipCallback;
  }
}

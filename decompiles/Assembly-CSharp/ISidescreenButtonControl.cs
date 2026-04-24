// Decompiled with JetBrains decompiler
// Type: ISidescreenButtonControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface ISidescreenButtonControl
{
  string SidescreenButtonText { get; }

  string SidescreenButtonTooltip { get; }

  void SetButtonTextOverride(ButtonMenuTextOverride textOverride);

  bool SidescreenEnabled();

  bool SidescreenButtonInteractable();

  void OnSidescreenButtonPressed();

  int HorizontalGroupID();

  int ButtonSideScreenSortOrder();
}

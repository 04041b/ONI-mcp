// Decompiled with JetBrains decompiler
// Type: INToggleSideScreenControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public interface INToggleSideScreenControl
{
  string SidescreenTitleKey { get; }

  List<LocString> Options { get; }

  List<LocString> Tooltips { get; }

  string Description { get; }

  int SelectedOption { get; }

  int QueuedOption { get; }

  void QueueSelectedOption(int option);
}

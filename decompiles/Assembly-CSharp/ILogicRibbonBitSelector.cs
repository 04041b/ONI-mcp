// Decompiled with JetBrains decompiler
// Type: ILogicRibbonBitSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface ILogicRibbonBitSelector
{
  void SetBitSelection(int bit);

  int GetBitSelection();

  int GetBitDepth();

  string SideScreenTitle { get; }

  string SideScreenDescription { get; }

  bool SideScreenDisplayWriterDescription();

  bool SideScreenDisplayReaderDescription();

  bool IsBitActive(int bit);

  int GetOutputValue();

  int GetInputValue();

  void UpdateVisuals();
}

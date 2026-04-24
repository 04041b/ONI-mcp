// Decompiled with JetBrains decompiler
// Type: IConsumableUIItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IConsumableUIItem
{
  string ConsumableId { get; }

  string ConsumableName { get; }

  int MajorOrder { get; }

  int MinorOrder { get; }

  bool Display { get; }

  string OverrideSpriteName() => (string) null;

  bool RevealTest() => ConsumerManager.instance.isDiscovered(this.ConsumableId.ToTag());
}

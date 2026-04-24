// Decompiled with JetBrains decompiler
// Type: IAmountDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public interface IAmountDisplayer
{
  string GetValueString(Amount master, AmountInstance instance);

  string GetDescription(Amount master, AmountInstance instance);

  string GetTooltip(Amount master, AmountInstance instance);

  IAttributeFormatter Formatter { get; }
}

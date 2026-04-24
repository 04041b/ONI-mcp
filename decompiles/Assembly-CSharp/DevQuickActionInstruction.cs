// Decompiled with JetBrains decompiler
// Type: DevQuickActionInstruction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct DevQuickActionInstruction(string address, System.Action action)
{
  public string Address = address;
  public System.Action Action = action;

  public DevQuickActionInstruction(
    IDevQuickAction.CommonMenusNames category,
    string name,
    System.Action action)
    : this($"{category.ToString()}/{name}", action)
  {
  }
}

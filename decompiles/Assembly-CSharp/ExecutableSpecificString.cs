// Decompiled with JetBrains decompiler
// Type: ExecutableSpecificString
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ExecutableSpecificString
{
  private string baseString;
  private string soString;

  public ExecutableSpecificString(string baseStr, string soStr)
  {
    this.baseString = baseStr;
    this.soString = soStr;
  }

  public static implicit operator string(ExecutableSpecificString dualString)
  {
    return !DlcManager.IsExpansion1Active() ? dualString.baseString : dualString.soString;
  }

  public static implicit operator LocString(ExecutableSpecificString dualString)
  {
    return new LocString((string) dualString);
  }
}

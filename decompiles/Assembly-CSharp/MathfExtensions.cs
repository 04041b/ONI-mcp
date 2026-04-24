// Decompiled with JetBrains decompiler
// Type: MathfExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class MathfExtensions
{
  public static long Max(this long a, long b) => a < b ? b : a;

  public static long Min(this long a, long b) => a > b ? b : a;
}

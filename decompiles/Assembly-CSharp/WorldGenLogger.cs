// Decompiled with JetBrains decompiler
// Type: WorldGenLogger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class WorldGenLogger
{
  public static void LogException(string message, string stack)
  {
    Debug.LogError((object) $"{message}\n{stack}");
  }
}

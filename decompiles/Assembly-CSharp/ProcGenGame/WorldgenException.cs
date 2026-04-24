// Decompiled with JetBrains decompiler
// Type: ProcGenGame.WorldgenException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace ProcGenGame;

public class WorldgenException : Exception
{
  public readonly string userMessage;

  public WorldgenException(string message, string userMessage)
    : base(message)
  {
    this.userMessage = userMessage;
  }
}

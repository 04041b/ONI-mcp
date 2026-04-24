// Decompiled with JetBrains decompiler
// Type: KMod.Content
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace KMod;

[Flags]
public enum Content : byte
{
  LayerableFiles = 1,
  Strings = 2,
  DLL = 4,
  Translation = 8,
  Animation = 16, // 0x10
}

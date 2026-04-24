// Decompiled with JetBrains decompiler
// Type: IEffectDescriptor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
[Obsolete("No longer used. Use IGameObjectEffectDescriptor instead", false)]
public interface IEffectDescriptor
{
  List<Descriptor> GetDescriptors(BuildingDef def);
}

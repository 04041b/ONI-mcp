// Decompiled with JetBrains decompiler
// Type: KMod.LoadedModData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace KMod;

public class LoadedModData
{
  public Harmony harmony;
  public Dictionary<Assembly, UserMod2> userMod2Instances;
  public ICollection<Assembly> dlls;
  public ICollection<MethodBase> patched_methods;
}

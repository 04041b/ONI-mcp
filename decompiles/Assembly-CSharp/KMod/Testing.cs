// Decompiled with JetBrains decompiler
// Type: KMod.Testing
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace KMod;

public static class Testing
{
  public static Testing.DLLLoading dll_loading;
  public const Testing.SaveLoad SAVE_LOAD = Testing.SaveLoad.NoTesting;
  public const Testing.Install INSTALL = Testing.Install.NoTesting;
  public const Testing.Boot BOOT = Testing.Boot.NoTesting;
  public const Testing.DiskIo DISK_IO = Testing.DiskIo.NoTesting;

  public enum DLLLoading
  {
    NoTesting,
    Fail,
    UseModLoaderDLLExclusively,
  }

  public enum SaveLoad
  {
    NoTesting,
    FailSave,
    FailLoad,
  }

  public enum Install
  {
    NoTesting,
    ForceUninstall,
    ForceReinstall,
    ForceUpdate,
  }

  public enum Boot
  {
    NoTesting,
    Crash,
  }

  [Flags]
  public enum DiskIo
  {
    NoTesting = 0,
    FailDeleteDirectory = 1,
    FailCreateDirectory = 2,
  }
}

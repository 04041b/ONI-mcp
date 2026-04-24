// Decompiled with JetBrains decompiler
// Type: KMod.IFileSource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using System.Collections.Generic;

#nullable disable
namespace KMod;

public interface IFileSource
{
  string GetRoot();

  bool Exists();

  bool Exists(string relative_path);

  void GetTopLevelItems(List<FileSystemItem> file_system_items, string relative_root = "");

  IFileDirectory GetFileSystem();

  bool TryCopyTo(string path, List<string> extensions = null);

  void CopyTo(string path, List<string> extensions = null) => this.TryCopyTo(path, extensions);

  string Read(string relative_path);

  void Dispose();
}

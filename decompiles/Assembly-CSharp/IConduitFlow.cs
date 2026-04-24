// Decompiled with JetBrains decompiler
// Type: IConduitFlow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public interface IConduitFlow
{
  void AddConduitUpdater(Action<float> callback, ConduitFlowPriority priority = ConduitFlowPriority.Default);

  void RemoveConduitUpdater(Action<float> callback);

  bool IsConduitEmpty(int cell);
}

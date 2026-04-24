// Decompiled with JetBrains decompiler
// Type: IScheduler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public interface IScheduler
{
  SchedulerHandle Schedule(
    string name,
    float time,
    Action<object> callback,
    object callback_data = null,
    SchedulerGroup group = null);
}

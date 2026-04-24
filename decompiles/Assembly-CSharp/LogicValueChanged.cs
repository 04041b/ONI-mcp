// Decompiled with JetBrains decompiler
// Type: LogicValueChanged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine.Pool;

#nullable disable
public class LogicValueChanged
{
  public HashedString portID;
  public int newValue;
  public int prevValue;
  public static ObjectPool<LogicValueChanged> Pool = new ObjectPool<LogicValueChanged>((Func<LogicValueChanged>) (() => new LogicValueChanged()), collectionCheck: false, defaultCapacity: 1, maxSize: 8);
}

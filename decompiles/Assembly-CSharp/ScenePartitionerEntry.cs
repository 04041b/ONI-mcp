// Decompiled with JetBrains decompiler
// Type: ScenePartitionerEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine.Pool;

#nullable disable
public class ScenePartitionerEntry
{
  public int x;
  public int y;
  public int width;
  public int height;
  public int layer;
  public int queryId;
  public ScenePartitioner partitioner;
  public Action<object> eventCallback;
  public object obj;
  public static ObjectPool<ScenePartitionerEntry> EntryPool = new ObjectPool<ScenePartitionerEntry>((Func<ScenePartitionerEntry>) (() => new ScenePartitionerEntry()), collectionCheck: false, defaultCapacity: 1024 /*0x0400*/);

  public void Init(
    string name,
    object obj,
    int x,
    int y,
    int width,
    int height,
    ScenePartitionerLayer layer,
    ScenePartitioner partitioner,
    Action<object> event_callback)
  {
    if (x >= 0 && y >= 0 && width >= 0)
      ;
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.layer = layer.layer;
    this.partitioner = partitioner;
    this.eventCallback = event_callback;
    this.obj = obj;
  }

  public void UpdatePosition(HandleVector<int>.Handle handle, int x, int y)
  {
    this.partitioner.UpdatePosition(x, y, handle);
  }

  public void UpdatePosition(HandleVector<int>.Handle handle, Extents e)
  {
    this.partitioner.UpdatePosition(e, handle);
  }

  public void Release(HandleVector<int>.Handle handle)
  {
    if (this.partitioner == null)
      return;
    this.partitioner.Remove(handle);
  }
}

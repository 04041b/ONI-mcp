// Decompiled with JetBrains decompiler
// Type: ScenePartitionerLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class ScenePartitionerLayer
{
  public HashedString name;
  public int layer;
  public Action<int, object> OnEvent;

  public ScenePartitionerLayer(HashedString name, int layer)
  {
    this.name = name;
    this.layer = layer;
  }
}

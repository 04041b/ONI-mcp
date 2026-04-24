// Decompiled with JetBrains decompiler
// Type: StampToolPreviewContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class StampToolPreviewContext
{
  public Transform previewParent;
  public InterfaceTool tool;
  public TemplateContainer stampTemplate;
  public System.Action frameAfterSetupFn;
  public Action<int> refreshFn;
  public System.Action onPlaceFn;
  public Action<string> onErrorChangeFn;
  public System.Action cleanupFn;
}

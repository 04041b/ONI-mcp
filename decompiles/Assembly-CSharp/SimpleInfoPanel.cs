// Decompiled with JetBrains decompiler
// Type: SimpleInfoPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SimpleInfoPanel
{
  protected SimpleInfoScreen simpleInfoRoot;

  public SimpleInfoPanel(SimpleInfoScreen simpleInfoRoot) => this.simpleInfoRoot = simpleInfoRoot;

  public virtual void Refresh(CollapsibleDetailContentPanel panel, GameObject selectedTarget)
  {
  }
}

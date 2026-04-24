// Decompiled with JetBrains decompiler
// Type: SideScreenContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public abstract class SideScreenContent : KScreen
{
  [SerializeField]
  protected string titleKey;
  public GameObject ContentContainer;
  public Func<bool> CheckShouldShowTopTitle;

  public virtual void SetTarget(GameObject target)
  {
  }

  public virtual void ClearTarget()
  {
  }

  public abstract bool IsValidForTarget(GameObject target);

  public virtual int GetSideScreenSortOrder() => 0;

  public virtual string GetTitle() => (string) Strings.Get(this.titleKey);
}

// Decompiled with JetBrains decompiler
// Type: RoleStationSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RoleStationSideScreen : SideScreenContent
{
  public GameObject content;
  private GameObject target;
  public LocText DescriptionText;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  public override bool IsValidForTarget(GameObject target) => false;
}

// Decompiled with JetBrains decompiler
// Type: PlanSubCategoryToggle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlanSubCategoryToggle : KMonoBehaviour
{
  [SerializeField]
  private MultiToggle toggle;
  [SerializeField]
  private GameObject gridContainer;
  private bool open = true;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.toggle.onClick += (System.Action) (() =>
    {
      this.open = !this.open;
      this.gridContainer.SetActive(this.open);
      this.toggle.ChangeState(this.open ? 0 : 1);
    });
  }
}

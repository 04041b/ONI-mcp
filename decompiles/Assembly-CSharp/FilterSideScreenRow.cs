// Decompiled with JetBrains decompiler
// Type: FilterSideScreenRow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/FilterSideScreenRow")]
public class FilterSideScreenRow : SingleItemSelectionRow
{
  public override string InvalidTagTitle => (string) UI.UISIDESCREENS.FILTERSIDESCREEN.NO_SELECTION;

  protected override void SetIcon(Sprite sprite, Color color)
  {
    if (!((Object) this.icon != (Object) null))
      return;
    this.icon.gameObject.SetActive(false);
  }
}

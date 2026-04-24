// Decompiled with JetBrains decompiler
// Type: DropdownSample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TMPro;
using UnityEngine;

#nullable disable
public class DropdownSample : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI text;
  [SerializeField]
  private TMP_Dropdown dropdownWithoutPlaceholder;
  [SerializeField]
  private TMP_Dropdown dropdownWithPlaceholder;

  public void OnButtonClick()
  {
    this.text.text = this.dropdownWithPlaceholder.value > -1 ? $"Selected values:\n{this.dropdownWithoutPlaceholder.value.ToString()} - {this.dropdownWithPlaceholder.value.ToString()}" : "Error: Please make a selection";
  }
}

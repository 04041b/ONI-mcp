// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_Fallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiPermitDioramaVis_Fallback : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private Image sprite;
  [SerializeField]
  private RectTransform editorOnlyErrorMessageParent;
  [SerializeField]
  private TextMeshProUGUI editorOnlyErrorMessageText;
  private Option<string> error;

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
  }

  public void ConfigureWith(PermitResource permit)
  {
    this.sprite.sprite = PermitPresentationInfo.GetUnknownSprite();
    this.editorOnlyErrorMessageParent.gameObject.SetActive(false);
  }

  public KleiPermitDioramaVis_Fallback WithError(string error)
  {
    this.error = (Option<string>) error;
    Debug.Log((object) ("[KleiInventoryScreen Error] Had to use fallback vis. " + error));
    return this;
  }
}

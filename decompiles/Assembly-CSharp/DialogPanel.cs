// Decompiled with JetBrains decompiler
// Type: DialogPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class DialogPanel : MonoBehaviour, IDeselectHandler, IEventSystemHandler
{
  public bool destroyOnDeselect = true;

  public void OnDeselect(BaseEventData eventData)
  {
    if (this.destroyOnDeselect)
    {
      foreach (Component component in this.transform)
        Util.KDestroyGameObject(component.gameObject);
    }
    this.gameObject.SetActive(false);
  }
}

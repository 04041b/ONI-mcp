// Decompiled with JetBrains decompiler
// Type: SelectablePanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class SelectablePanel : MonoBehaviour, IDeselectHandler, IEventSystemHandler
{
  public void OnDeselect(BaseEventData evt) => this.gameObject.SetActive(false);
}

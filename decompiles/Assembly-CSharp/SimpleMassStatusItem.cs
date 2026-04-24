// Decompiled with JetBrains decompiler
// Type: SimpleMassStatusItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SimpleMassStatusItem")]
public class SimpleMassStatusItem : KMonoBehaviour
{
  public string symbolPrefix = "";

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<KSelectable>().AddStatusItem(Db.Get().MiscStatusItems.OreMass, (object) this.gameObject);
  }
}

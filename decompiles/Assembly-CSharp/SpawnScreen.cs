// Decompiled with JetBrains decompiler
// Type: SpawnScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SpawnScreen")]
public class SpawnScreen : KMonoBehaviour
{
  public GameObject Screen;

  protected override void OnPrefabInit() => Util.KInstantiateUI(this.Screen, this.gameObject);
}

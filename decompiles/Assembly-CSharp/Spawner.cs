// Decompiled with JetBrains decompiler
// Type: Spawner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/scripts/Spawner")]
public class Spawner : KMonoBehaviour, ISaveLoadable
{
  [Serialize]
  public Tag prefabTag;
  [Serialize]
  public int units = 1;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    SaveGame.Instance.worldGenSpawner.AddLegacySpawner(this.prefabTag, Grid.PosToCell((KMonoBehaviour) this));
    Util.KDestroyGameObject(this.gameObject);
  }
}

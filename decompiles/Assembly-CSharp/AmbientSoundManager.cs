// Decompiled with JetBrains decompiler
// Type: AmbientSoundManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/AmbientSoundManager")]
public class AmbientSoundManager : KMonoBehaviour
{
  [MyCmpAdd]
  private LoopingSounds loopingSounds;

  public static AmbientSoundManager Instance { get; private set; }

  public static void Destroy() => AmbientSoundManager.Instance = (AmbientSoundManager) null;

  protected override void OnPrefabInit() => AmbientSoundManager.Instance = this;

  protected override void OnSpawn() => base.OnSpawn();

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    AmbientSoundManager.Instance = (AmbientSoundManager) null;
  }
}

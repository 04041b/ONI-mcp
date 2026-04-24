// Decompiled with JetBrains decompiler
// Type: EntityPrefabs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/EntityPrefabs")]
public class EntityPrefabs : KMonoBehaviour
{
  public GameObject SelectMarker;
  public GameObject ForegroundLayer;

  public static EntityPrefabs Instance { get; private set; }

  public static void DestroyInstance() => EntityPrefabs.Instance = (EntityPrefabs) null;

  protected override void OnPrefabInit() => EntityPrefabs.Instance = this;
}

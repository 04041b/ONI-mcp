// Decompiled with JetBrains decompiler
// Type: MouthAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MouthAnimation : IEntityConfig
{
  public static string ID = nameof (MouthAnimation);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(MouthAnimation.ID, MouthAnimation.ID, false);
    entity.AddOrGet<KBatchedAnimController>().AnimFiles = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_mouth_flap_kanim")
    };
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}

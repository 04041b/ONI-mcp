// Decompiled with JetBrains decompiler
// Type: GravitasCeilingLightConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class GravitasCeilingLightConfig : IEntityConfig
{
  public GameObject CreatePrefab()
  {
    string name = (string) STRINGS.BUILDINGS.PREFABS.PROPGRAVITASCEILINGLIGHT.NAME;
    string desc = (string) STRINGS.BUILDINGS.PREFABS.PROPGRAVITASCEILINGLIGHT.DESC;
    EffectorValues tieR0_1 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues tieR0_2 = NOISE_POLLUTION.NOISY.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) "gravitas_light2_kanim");
    EffectorValues decor = tieR0_1;
    EffectorValues noise = tieR0_2;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("GravitasCeilingLight", name, desc, 25f, anim, "off", Grid.SceneLayer.Building, 1, 1, decor, PermittedRotations.Unrotatable, noise: noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.IronOre);
    component.Temperature = 294.15f;
    LoreBearerUtil.AddLoreTo(placedEntity, new LoreBearerAction(LoreBearerUtil.UnlockNextEmail));
    placedEntity.AddOrGet<Demolishable>();
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
    inst.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

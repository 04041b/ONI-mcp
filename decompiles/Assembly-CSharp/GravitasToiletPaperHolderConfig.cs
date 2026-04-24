// Decompiled with JetBrains decompiler
// Type: GravitasToiletPaperHolderConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class GravitasToiletPaperHolderConfig : IEntityConfig
{
  public const string ID = "GravitasToiletPaperHolder";

  public GameObject CreatePrefab()
  {
    string name = (string) STRINGS.BUILDINGS.PREFABS.PROPGRAVITASBATHROOMTOILETPAPERHOLDER.NAME;
    string desc = (string) STRINGS.BUILDINGS.PREFABS.PROPGRAVITASBATHROOMTOILETPAPERHOLDER.DESC;
    EffectorValues tieR0_1 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues tieR0_2 = NOISE_POLLUTION.NOISY.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) "gravitas_toilet_paper_holder_kanim");
    EffectorValues decor = tieR0_1;
    EffectorValues noise = tieR0_2;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("GravitasToiletPaperHolder", name, desc, 50f, anim, "on", Grid.SceneLayer.Building, 1, 1, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Granite);
    component.Temperature = 294.15f;
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

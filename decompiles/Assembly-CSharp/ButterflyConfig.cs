// Decompiled with JetBrains decompiler
// Type: ButterflyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(1)]
public class ButterflyConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "Butterfly";
  public const string BASE_TRAIT_ID = "ButterflyBaseTrait";

  public static GameObject CreateButterfly(string id, string name, string desc, string anim_file)
  {
    GameObject go = BaseButterflyConfig.BaseButterfly(id, name, desc, anim_file, "ButterflyBaseTrait");
    go.AddOrGetDef<AgeMonitor.Def>();
    go.AddOrGetDef<FixedCapturableMonitor.Def>();
    Trait trait = Db.Get().CreateTrait("ButterflyBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 5f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 5f, name));
    go.AddTag(GameTags.OriginalCreature);
    return go;
  }

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject butterfly = ButterflyConfig.CreateButterfly("Butterfly", (string) CREATURES.SPECIES.BUTTERFLY.NAME, (string) CREATURES.SPECIES.BUTTERFLY.DESC, "pollinator_kanim");
    butterfly.AddTag(GameTags.Creatures.Pollinator);
    return butterfly;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

// Decompiled with JetBrains decompiler
// Type: BabyStaterpillarLiquidConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(4)]
public class BabyStaterpillarLiquidConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "StaterpillarLiquidBaby";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject staterpillarLiquid = StaterpillarLiquidConfig.CreateStaterpillarLiquid("StaterpillarLiquidBaby", (string) CREATURES.SPECIES.STATERPILLAR.VARIANT_LIQUID.BABY.NAME, (string) CREATURES.SPECIES.STATERPILLAR.VARIANT_LIQUID.BABY.DESC, "baby_caterpillar_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(staterpillarLiquid, (Tag) "StaterpillarLiquid");
    return staterpillarLiquid;
  }

  public void OnPrefabInit(GameObject prefab)
  {
    prefab.GetComponent<KBatchedAnimController>().SetSymbolVisiblity((KAnimHashedString) "electric_bolt_c_bloom", false);
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

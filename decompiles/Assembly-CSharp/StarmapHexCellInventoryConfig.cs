// Decompiled with JetBrains decompiler
// Type: StarmapHexCellInventoryConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class StarmapHexCellInventoryConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "StarmapHexCellInventory";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity("StarmapHexCellInventory", (string) UI.CLUSTERMAP.HEXCELL_INVENTORY.NAME);
    entity.AddOrGet<SaveLoadRoot>();
    entity.AddOrGet<StarmapHexCellInventory>();
    entity.AddOrGet<StarmapHexCellInventoryVisuals>();
    entity.AddOrGet<InfoDescription>().description = (string) UI.CLUSTERMAP.HEXCELL_INVENTORY.DESC;
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}

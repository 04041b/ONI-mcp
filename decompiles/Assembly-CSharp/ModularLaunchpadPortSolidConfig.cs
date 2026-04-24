// Decompiled with JetBrains decompiler
// Type: ModularLaunchpadPortSolidConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ModularLaunchpadPortSolidConfig : IBuildingConfig
{
  public const string ID = "ModularLaunchpadPortSolid";

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    return BaseModularLaunchpadPortConfig.CreateBaseLaunchpadPort("ModularLaunchpadPortSolid", "conduit_port_solid_loader_kanim", ConduitType.Solid, true, height: 2);
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    BaseModularLaunchpadPortConfig.ConfigureBuildingTemplate(go, prefab_tag, ConduitType.Solid, 20f, true);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    BaseModularLaunchpadPortConfig.DoPostConfigureComplete(go, true);
  }
}

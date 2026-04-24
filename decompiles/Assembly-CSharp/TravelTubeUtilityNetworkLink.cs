// Decompiled with JetBrains decompiler
// Type: TravelTubeUtilityNetworkLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class TravelTubeUtilityNetworkLink : UtilityNetworkLink, IHaveUtilityNetworkMgr
{
  protected override void OnSpawn() => base.OnSpawn();

  protected override void OnConnect(int cell1, int cell2)
  {
    Game.Instance.travelTubeSystem.AddLink(cell1, cell2);
  }

  protected override void OnDisconnect(int cell1, int cell2)
  {
    Game.Instance.travelTubeSystem.RemoveLink(cell1, cell2);
  }

  public IUtilityNetworkMgr GetNetworkManager()
  {
    return (IUtilityNetworkMgr) Game.Instance.travelTubeSystem;
  }
}

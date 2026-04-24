// Decompiled with JetBrains decompiler
// Type: PartialLightBlocking
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class PartialLightBlocking : KMonoBehaviour
{
  private const byte PartialLightBlockingProperties = 48 /*0x30*/;

  protected override void OnSpawn()
  {
    this.SetLightBlocking();
    base.OnSpawn();
  }

  protected override void OnCleanUp()
  {
    this.ClearLightBlocking();
    base.OnCleanUp();
  }

  public void SetLightBlocking()
  {
    foreach (int placementCell in this.GetComponent<Building>().PlacementCells)
      SimMessages.SetCellProperties(placementCell, (byte) 48 /*0x30*/);
  }

  public void ClearLightBlocking()
  {
    foreach (int placementCell in this.GetComponent<Building>().PlacementCells)
      SimMessages.ClearCellProperties(placementCell, (byte) 48 /*0x30*/);
  }
}

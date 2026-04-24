// Decompiled with JetBrains decompiler
// Type: ConduitBridgeBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ConduitBridgeBase : KMonoBehaviour
{
  public ConduitBridgeBase.DesiredMassTransfer desiredMassTransfer;
  public ConduitBridgeBase.ConduitBridgeEvent OnMassTransfer;

  protected void SendEmptyOnMassTransfer()
  {
    if (this.OnMassTransfer == null)
      return;
    this.OnMassTransfer(SimHashes.Void, 0.0f, 0.0f, (byte) 0, 0, (Pickupable) null);
  }

  public delegate float DesiredMassTransfer(
    float dt,
    SimHashes element,
    float mass,
    float temperature,
    byte disease_idx,
    int disease_count,
    Pickupable pickupable);

  public delegate void ConduitBridgeEvent(
    SimHashes element,
    float mass,
    float temperature,
    byte disease_idx,
    int disease_count,
    Pickupable pickupable);
}

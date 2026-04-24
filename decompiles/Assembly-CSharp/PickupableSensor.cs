// Decompiled with JetBrains decompiler
// Type: PickupableSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PickupableSensor : Sensor
{
  private Navigator navigator;
  private WorkerBase worker;

  public PickupableSensor(Sensors sensors)
    : base(sensors)
  {
    this.worker = this.GetComponent<WorkerBase>();
    this.navigator = this.GetComponent<Navigator>();
  }

  public override void Update()
  {
    GlobalChoreProvider.Instance.UpdateFetches(this.navigator);
    Game.Instance.fetchManager.UpdatePickups(this.navigator, this.worker);
  }
}

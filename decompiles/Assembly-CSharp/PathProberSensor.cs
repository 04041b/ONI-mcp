// Decompiled with JetBrains decompiler
// Type: PathProberSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PathProberSensor : Sensor
{
  private Navigator navigator;

  public PathProberSensor(Sensors sensors)
    : base(sensors)
  {
    this.navigator = sensors.GetComponent<Navigator>();
  }

  public override void Update() => this.navigator.UpdateProbe();
}

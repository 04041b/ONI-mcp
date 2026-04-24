// Decompiled with JetBrains decompiler
// Type: HEPBridgeTileVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class HEPBridgeTileVisualizer : KMonoBehaviour, IHighEnergyParticleDirection
{
  private static readonly EventSystem.IntraObjectHandler<HEPBridgeTileVisualizer> OnRotateDelegate = new EventSystem.IntraObjectHandler<HEPBridgeTileVisualizer>((Action<HEPBridgeTileVisualizer, object>) ((component, data) => component.OnRotate()));

  protected override void OnSpawn()
  {
    this.Subscribe<HEPBridgeTileVisualizer>(-1643076535, HEPBridgeTileVisualizer.OnRotateDelegate);
    this.OnRotate();
  }

  public void OnRotate() => Game.Instance.ForceOverlayUpdate(true);

  public EightDirection Direction
  {
    get
    {
      EightDirection direction = EightDirection.Right;
      Rotatable component = this.GetComponent<Rotatable>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        switch (component.Orientation)
        {
          case Orientation.Neutral:
            direction = EightDirection.Left;
            break;
          case Orientation.R90:
            direction = EightDirection.Up;
            break;
          case Orientation.R180:
            direction = EightDirection.Right;
            break;
          case Orientation.R270:
            direction = EightDirection.Down;
            break;
        }
      }
      return direction;
    }
    set
    {
    }
  }
}

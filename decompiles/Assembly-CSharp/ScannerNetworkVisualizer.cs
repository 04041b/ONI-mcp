// Decompiled with JetBrains decompiler
// Type: ScannerNetworkVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ScannerNetworkVisualizer")]
public class ScannerNetworkVisualizer : KMonoBehaviour
{
  public Vector2I OriginOffset = new Vector2I(0, 0);
  public int RangeMin;
  public int RangeMax;

  protected override void OnSpawn()
  {
    Components.ScannerVisualizers.Add(this.gameObject.GetMyWorldId(), this);
  }

  protected override void OnCleanUp()
  {
    Components.ScannerVisualizers.Remove(this.gameObject.GetMyWorldId(), this);
  }
}

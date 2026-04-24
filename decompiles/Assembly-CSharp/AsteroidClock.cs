// Decompiled with JetBrains decompiler
// Type: AsteroidClock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class AsteroidClock : MonoBehaviour
{
  public Transform rotationTransform;
  public Image NightOverlay;

  private void Awake() => this.UpdateOverlay();

  private void Start()
  {
  }

  private void Update()
  {
    if (!((Object) GameClock.Instance != (Object) null))
      return;
    this.rotationTransform.rotation = Quaternion.Euler(0.0f, 0.0f, (float) (360.0 * -(double) GameClock.Instance.GetCurrentCycleAsPercentage()));
  }

  private void UpdateOverlay() => this.NightOverlay.fillAmount = 0.125f;
}

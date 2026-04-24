// Decompiled with JetBrains decompiler
// Type: StarmapPlanetVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/StarmapPlanetVisualizer")]
public class StarmapPlanetVisualizer : KMonoBehaviour
{
  public Image image;
  public LocText label;
  public MultiToggle button;
  public RectTransform selection;
  public GameObject analysisSelection;
  public Image unknownBG;
  public GameObject rocketIconContainer;
}

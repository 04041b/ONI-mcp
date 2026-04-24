// Decompiled with JetBrains decompiler
// Type: ProgressBarsConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ProgressBarsConfig : ScriptableObject
{
  public GameObject progressBarPrefab;
  public GameObject progressBarUIPrefab;
  public GameObject healthBarPrefab;
  public List<ProgressBarsConfig.BarData> barColorDataList = new List<ProgressBarsConfig.BarData>();
  public Dictionary<string, ProgressBarsConfig.BarData> barColorMap = new Dictionary<string, ProgressBarsConfig.BarData>();
  private static ProgressBarsConfig instance;

  public static void DestroyInstance() => ProgressBarsConfig.instance = (ProgressBarsConfig) null;

  public static ProgressBarsConfig Instance
  {
    get
    {
      if ((UnityEngine.Object) ProgressBarsConfig.instance == (UnityEngine.Object) null)
      {
        ProgressBarsConfig.instance = Resources.Load<ProgressBarsConfig>(nameof (ProgressBarsConfig));
        ProgressBarsConfig.instance.Initialize();
      }
      return ProgressBarsConfig.instance;
    }
  }

  public void Initialize()
  {
    foreach (ProgressBarsConfig.BarData barColorData in this.barColorDataList)
      this.barColorMap.Add(barColorData.barName, barColorData);
  }

  public string GetBarDescription(string barName)
  {
    string barDescription = "";
    if (this.IsBarNameValid(barName))
      barDescription = (string) Strings.Get(this.barColorMap[barName].barDescriptionKey);
    return barDescription;
  }

  public Color GetBarColor(string barName)
  {
    Color barColor = Color.clear;
    if (this.IsBarNameValid(barName))
      barColor = this.barColorMap[barName].barColor;
    return barColor;
  }

  public bool IsBarNameValid(string barName)
  {
    if (string.IsNullOrEmpty(barName))
    {
      Debug.LogError((object) "The barName provided was null or empty. Don't do that.");
      return false;
    }
    if (this.barColorMap.ContainsKey(barName))
      return true;
    Debug.LogError((object) $"No BarData found for the entry [ {barName} ]");
    return false;
  }

  [Serializable]
  public struct BarData
  {
    public string barName;
    public Color barColor;
    public string barDescriptionKey;
  }
}

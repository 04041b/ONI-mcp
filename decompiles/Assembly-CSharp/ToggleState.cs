// Decompiled with JetBrains decompiler
// Type: ToggleState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public struct ToggleState
{
  public string Name;
  public string on_click_override_sound_path;
  public string on_release_override_sound_path;
  public string sound_parameter_name;
  public float sound_parameter_value;
  public bool has_sound_parameter;
  public Sprite sprite;
  public Color color;
  public Color color_on_hover;
  public bool use_color_on_hover;
  public bool use_rect_margins;
  public Vector2 rect_margins;
  public StatePresentationSetting[] additional_display_settings;
}

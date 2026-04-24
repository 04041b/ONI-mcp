// Decompiled with JetBrains decompiler
// Type: RailModUploadScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using TMPro;
using UnityEngine;

#nullable disable
public class RailModUploadScreen : KModalScreen
{
  [SerializeField]
  private KButton[] closeButtons;
  [SerializeField]
  private KButton submitButton;
  [SerializeField]
  private ToolTip submitButtonTooltip;
  [SerializeField]
  private TMP_InputField modName;
  [SerializeField]
  private TMP_InputField modDesc;
  [SerializeField]
  private TMP_InputField modVersion;
  [SerializeField]
  private TMP_InputField contentFolder;
  [SerializeField]
  private TMP_InputField previewImage;
  [SerializeField]
  private MultiToggle[] shareTypeToggles;
  [Serialize]
  private string previousFolderPath;
}

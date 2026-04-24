// Decompiled with JetBrains decompiler
// Type: VideoOverlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/VideoOverlay")]
public class VideoOverlay : KMonoBehaviour
{
  public List<LocText> textFields;

  public void SetText(List<string> strings)
  {
    if (strings.Count != this.textFields.Count)
      DebugUtil.LogErrorArgs((object) this.name, (object) "expects", (object) this.textFields.Count, (object) "strings passed to it, got", (object) strings.Count);
    for (int index = 0; index < this.textFields.Count; ++index)
      this.textFields[index].text = strings[index];
  }
}

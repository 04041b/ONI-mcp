// Decompiled with JetBrains decompiler
// Type: ButtonMenuTextOverride
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[Serializable]
public struct ButtonMenuTextOverride
{
  public LocString Text;
  public LocString CancelText;
  public LocString ToolTip;
  public LocString CancelToolTip;

  public bool IsValid
  {
    get
    {
      return !string.IsNullOrEmpty((string) this.Text) && !string.IsNullOrEmpty((string) this.ToolTip);
    }
  }

  public bool HasCancelText
  {
    get
    {
      return !string.IsNullOrEmpty((string) this.CancelText) && !string.IsNullOrEmpty((string) this.CancelToolTip);
    }
  }
}

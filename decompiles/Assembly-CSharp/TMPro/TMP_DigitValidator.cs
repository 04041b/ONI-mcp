// Decompiled with JetBrains decompiler
// Type: TMPro.TMP_DigitValidator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace TMPro;

[Serializable]
public class TMP_DigitValidator : TMP_InputValidator
{
  public override char Validate(ref string text, ref int pos, char ch)
  {
    if (ch < '0' || ch > '9')
      return char.MinValue;
    text += ch.ToString();
    ++pos;
    return ch;
  }
}

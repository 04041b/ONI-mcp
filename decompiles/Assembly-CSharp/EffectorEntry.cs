// Decompiled with JetBrains decompiler
// Type: EffectorEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
internal struct EffectorEntry(string name, float value)
{
  public string name = name;
  public int count = 1;
  public float value = value;

  public override string ToString()
  {
    string str = "";
    if (this.count > 1)
      str = string.Format((string) UI.OVERLAYS.DECOR.COUNT, (object) this.count);
    return string.Format((string) UI.OVERLAYS.DECOR.ENTRY, (object) GameUtil.GetFormattedDecor(this.value), (object) this.name, (object) str);
  }
}

// Decompiled with JetBrains decompiler
// Type: TagNameComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class TagNameComparer : IComparer<Tag>
{
  private Tag firstTag;

  public TagNameComparer()
  {
  }

  public TagNameComparer(Tag firstTag) => this.firstTag = firstTag;

  public int Compare(Tag x, Tag y)
  {
    if (x == y)
      return 0;
    if (this.firstTag.IsValid)
    {
      if (x == this.firstTag && y != this.firstTag)
        return 1;
      if (x != this.firstTag && y == this.firstTag)
        return -1;
    }
    return x.ProperNameStripLink().CompareTo(y.ProperNameStripLink());
  }
}

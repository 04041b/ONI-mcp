// Decompiled with JetBrains decompiler
// Type: IReadonlyTags
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IReadonlyTags
{
  bool HasTag(string tag);

  bool HasTag(int hashtag);

  bool HasTags(int[] tags);
}

// Decompiled with JetBrains decompiler
// Type: Database.CritterEmotion
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Database;

public class CritterEmotion
{
  public string id;
  public bool isPositiveEmotion;
  public Sprite sprite;

  public CritterEmotion(string id, bool isPositiveEmotion, Sprite sprite)
  {
    this.id = id;
    this.isPositiveEmotion = isPositiveEmotion;
    this.sprite = sprite;
  }
}

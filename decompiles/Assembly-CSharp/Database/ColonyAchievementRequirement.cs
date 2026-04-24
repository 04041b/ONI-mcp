// Decompiled with JetBrains decompiler
// Type: Database.ColonyAchievementRequirement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public abstract class ColonyAchievementRequirement
{
  public abstract bool Success();

  public virtual bool Fail() => false;

  public virtual string GetProgress(bool complete) => "";
}

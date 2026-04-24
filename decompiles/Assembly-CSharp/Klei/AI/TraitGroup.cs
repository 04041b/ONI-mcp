// Decompiled with JetBrains decompiler
// Type: Klei.AI.TraitGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI;

public class TraitGroup : ModifierGroup<Trait>
{
  public bool IsSpawnTrait;

  public TraitGroup(string id, string name, bool is_spawn_trait)
    : base(id, name)
  {
    this.IsSpawnTrait = is_spawn_trait;
  }
}

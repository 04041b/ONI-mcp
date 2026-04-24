// Decompiled with JetBrains decompiler
// Type: EntityModifierSet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class EntityModifierSet : ModifierSet
{
  public DuplicantStatusItems DuplicantStatusItems;
  public ChoreGroups ChoreGroups;

  public override void Initialize()
  {
    base.Initialize();
    this.DuplicantStatusItems = new DuplicantStatusItems(this.Root);
    this.ChoreGroups = new ChoreGroups(this.Root);
    this.LoadTraits();
  }
}

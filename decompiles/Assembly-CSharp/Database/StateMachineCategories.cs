// Decompiled with JetBrains decompiler
// Type: Database.StateMachineCategories
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Database;

public class StateMachineCategories : ResourceSet<StateMachine.Category>
{
  public StateMachine.Category Ai;
  public StateMachine.Category Monitor;
  public StateMachine.Category Chore;
  public StateMachine.Category Misc;

  public StateMachineCategories()
  {
    this.Ai = this.Add(new StateMachine.Category(nameof (Ai)));
    this.Monitor = this.Add(new StateMachine.Category(nameof (Monitor)));
    this.Chore = this.Add(new StateMachine.Category(nameof (Chore)));
    this.Misc = this.Add(new StateMachine.Category(nameof (Misc)));
  }
}

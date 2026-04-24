// Decompiled with JetBrains decompiler
// Type: VoidChoreProvider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class VoidChoreProvider : ChoreProvider
{
  public static VoidChoreProvider Instance;

  public static void DestroyInstance() => VoidChoreProvider.Instance = (VoidChoreProvider) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    VoidChoreProvider.Instance = this;
  }

  public override void AddChore(Chore chore)
  {
  }

  public override void RemoveChore(Chore chore)
  {
  }

  public override void CollectChores(
    ChoreConsumerState consumer_state,
    List<Chore.Precondition.Context> succeeded,
    List<Chore.Precondition.Context> failed_contexts)
  {
  }
}

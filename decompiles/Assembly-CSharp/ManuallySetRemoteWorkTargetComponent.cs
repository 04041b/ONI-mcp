// Decompiled with JetBrains decompiler
// Type: ManuallySetRemoteWorkTargetComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ManuallySetRemoteWorkTargetComponent : RemoteDockWorkTargetComponent
{
  private Chore chore;

  public override Chore RemoteDockChore => this.chore;

  public void SetChore(Chore chore_) => this.chore = chore_;
}

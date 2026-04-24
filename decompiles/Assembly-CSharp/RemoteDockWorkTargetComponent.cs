// Decompiled with JetBrains decompiler
// Type: RemoteDockWorkTargetComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class RemoteDockWorkTargetComponent : KMonoBehaviour, IRemoteDockWorkTarget
{
  protected override void OnSpawn()
  {
    base.OnSpawn();
    Components.RemoteDockWorkTargets.Add(this.gameObject.GetMyWorldId(), (IRemoteDockWorkTarget) this);
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    Components.RemoteDockWorkTargets.Remove(this.gameObject.GetMyWorldId(), (IRemoteDockWorkTarget) this);
  }

  public abstract Chore RemoteDockChore { get; }

  public virtual IApproachable Approachable => this.gameObject.GetComponent<IApproachable>();
}

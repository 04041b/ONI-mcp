// Decompiled with JetBrains decompiler
// Type: TargetMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
public abstract class TargetMessage : Message
{
  [Serialize]
  private MessageTarget target;

  protected TargetMessage()
  {
  }

  public TargetMessage(KPrefabID prefab_id) => this.target = new MessageTarget(prefab_id);

  public MessageTarget GetTarget() => this.target;

  public override void OnCleanUp() => this.target.OnCleanUp();
}

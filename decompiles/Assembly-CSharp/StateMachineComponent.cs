// Decompiled with JetBrains decompiler
// Type: StateMachineComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public abstract class StateMachineComponent : KMonoBehaviour, ISaveLoadable, IStateMachineTarget
{
  [MyCmpAdd]
  protected StateMachineController stateMachineController;

  public abstract StateMachine.Instance GetSMI();
}

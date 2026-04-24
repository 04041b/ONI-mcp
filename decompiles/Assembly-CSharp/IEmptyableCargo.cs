// Decompiled with JetBrains decompiler
// Type: IEmptyableCargo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public interface IEmptyableCargo
{
  bool CanEmptyCargo();

  void EmptyCargo();

  IStateMachineTarget master { get; }

  bool CanAutoDeploy { get; }

  bool AutoDeploy { get; set; }

  bool ChooseDuplicant { get; }

  bool ModuleDeployed { get; }

  MinionIdentity ChosenDuplicant { get; set; }

  bool CanTargetClusterGridEntities => false;

  string GetButtonText => (string) UI.UISIDESCREENS.MODULEFLIGHTUTILITYSIDESCREEN.DEPLOY_BUTTON;

  string GetButtonToolip
  {
    get => (string) UI.UISIDESCREENS.MODULEFLIGHTUTILITYSIDESCREEN.DEPLOY_BUTTON_TOOLTIP;
  }
}

// Decompiled with JetBrains decompiler
// Type: UserNameable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/UserNameable")]
public class UserNameable : KMonoBehaviour
{
  [Serialize]
  public string savedName = "";

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (string.IsNullOrEmpty(this.savedName))
      this.SetName(this.gameObject.GetProperName());
    else
      this.SetName(this.savedName);
  }

  public void SetName(string name)
  {
    KSelectable component = this.GetComponent<KSelectable>();
    this.name = name;
    if ((Object) component != (Object) null)
      component.SetName(name);
    this.gameObject.name = name;
    NameDisplayScreen.Instance.UpdateName(this.gameObject);
    if ((Object) this.GetComponent<CommandModule>() != (Object) null)
      SpacecraftManager.instance.GetSpacecraftFromLaunchConditionManager(this.GetComponent<LaunchConditionManager>()).SetRocketName(name);
    else if ((Object) this.GetComponent<Clustercraft>() != (Object) null)
      ClusterNameDisplayScreen.Instance.UpdateName((ClusterGridEntity) this.GetComponent<Clustercraft>());
    this.savedName = name;
    this.Trigger(1102426921, (object) name);
  }
}

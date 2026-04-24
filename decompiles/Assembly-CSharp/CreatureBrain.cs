// Decompiled with JetBrains decompiler
// Type: CreatureBrain
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CreatureBrain : Brain
{
  public string symbolPrefix;
  public Tag species;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Navigator component = this.GetComponent<Navigator>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    if (this.GetComponent<KPrefabID>().HasTag(GameTags.Robots.Behaviours.HasDoorPermissions))
      component.SetAbilities((PathFinderAbilities) new RobotPathFinderAbilities(component));
    else
      component.SetAbilities((PathFinderAbilities) new CreaturePathFinderAbilities(component));
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.onPreUpdate += (System.Action) (() =>
    {
      Navigator component = this.GetComponent<Navigator>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.UpdateProbe();
    });
  }
}

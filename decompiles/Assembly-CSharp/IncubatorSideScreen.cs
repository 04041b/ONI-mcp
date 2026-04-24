// Decompiled with JetBrains decompiler
// Type: IncubatorSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class IncubatorSideScreen : ReceptacleSideScreen
{
  public DescriptorPanel RequirementsDescriptorPanel;
  public DescriptorPanel HarvestDescriptorPanel;
  public DescriptorPanel EffectsDescriptorPanel;
  public MultiToggle continuousToggle;

  public override bool IsValidForTarget(GameObject target)
  {
    return (UnityEngine.Object) target.GetComponent<EggIncubator>() != (UnityEngine.Object) null;
  }

  protected override void SetResultDescriptions(GameObject go)
  {
    string sourceText = "";
    InfoDescription component = go.GetComponent<InfoDescription>();
    if ((bool) (UnityEngine.Object) component)
      sourceText += component.description;
    this.descriptionLabel.SetText(sourceText);
  }

  protected override bool RequiresAvailableAmountToDeposit() => false;

  protected override Sprite GetEntityIcon(Tag prefabTag)
  {
    return Def.GetUISprite((object) Assets.GetPrefab(prefabTag)).first;
  }

  public override void SetTarget(GameObject target)
  {
    base.SetTarget(target);
    EggIncubator incubator = target.GetComponent<EggIncubator>();
    this.continuousToggle.ChangeState(incubator.autoReplaceEntity ? 0 : 1);
    this.continuousToggle.onClick = (System.Action) (() =>
    {
      incubator.autoReplaceEntity = !incubator.autoReplaceEntity;
      this.continuousToggle.ChangeState(incubator.autoReplaceEntity ? 0 : 1);
    });
  }
}

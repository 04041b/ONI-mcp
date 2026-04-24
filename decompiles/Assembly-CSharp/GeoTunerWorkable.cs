// Decompiled with JetBrains decompiler
// Type: GeoTunerWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class GeoTunerWorkable : Workable
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.SetWorkTime(30f);
    this.requiredSkillPerk = Db.Get().SkillPerks.AllowGeyserTuning.Id;
    this.SetWorkerStatusItem(Db.Get().DuplicantStatusItems.Studying);
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_geotuner_kanim")
    };
    this.attributeConverter = Db.Get().AttributeConverters.GeotuningSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.skillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.lightEfficiencyBonus = true;
  }
}

// Decompiled with JetBrains decompiler
// Type: SplatWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class SplatWorkable : Workable
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.SetOffsetTable(OffsetGroups.InvertedStandardTableWithCorners);
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Mopping;
    this.attributeConverter = Db.Get().AttributeConverters.TidyingSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Basekeeping.Id;
    this.skillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.multitoolContext = (HashedString) "disinfect";
    this.multitoolHitEffectTag = (Tag) "fx_disinfect_splash";
    this.synchronizeAnims = false;
    Prioritizable.AddRef(this.gameObject);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(5f);
  }
}

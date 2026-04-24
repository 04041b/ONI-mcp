// Decompiled with JetBrains decompiler
// Type: ScheduleGroupInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class ScheduleGroupInstance
{
  [Serialize]
  private string scheduleGroupID;
  [Serialize]
  public int segments;

  public ScheduleGroup scheduleGroup
  {
    get => Db.Get().ScheduleGroups.Get(this.scheduleGroupID);
    set => this.scheduleGroupID = value.Id;
  }

  public ScheduleGroupInstance(ScheduleGroup scheduleGroup)
  {
    this.scheduleGroup = scheduleGroup;
    this.segments = scheduleGroup.defaultSegments;
  }
}

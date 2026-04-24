// Decompiled with JetBrains decompiler
// Type: Database.EquipNDupes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class EquipNDupes : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private AssignableSlot equipmentSlot;
  private int numToEquip;

  public EquipNDupes(AssignableSlot equipmentSlot, int numToEquip)
  {
    this.equipmentSlot = equipmentSlot;
    this.numToEquip = numToEquip;
  }

  public override bool Success()
  {
    int num = 0;
    foreach (MinionIdentity minionIdentity in Components.MinionIdentities.Items)
    {
      Equipment equipment = minionIdentity.GetEquipment();
      if ((Object) equipment != (Object) null && equipment.IsSlotOccupied(this.equipmentSlot))
        ++num;
    }
    return num >= this.numToEquip;
  }

  public void Deserialize(IReader reader)
  {
    string id = reader.ReadKleiString();
    this.equipmentSlot = Db.Get().AssignableSlots.Get(id);
    this.numToEquip = reader.ReadInt32();
  }

  public override string GetProgress(bool complete)
  {
    int num = 0;
    foreach (MinionIdentity minionIdentity in Components.MinionIdentities.Items)
    {
      Equipment equipment = minionIdentity.GetEquipment();
      if ((Object) equipment != (Object) null && equipment.IsSlotOccupied(this.equipmentSlot))
        ++num;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.CLOTHE_DUPES, (object) (complete ? this.numToEquip : num), (object) this.numToEquip);
  }
}

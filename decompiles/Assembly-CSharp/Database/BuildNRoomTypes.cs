// Decompiled with JetBrains decompiler
// Type: Database.BuildNRoomTypes
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class BuildNRoomTypes : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private RoomType roomType;
  private int numToCreate;

  public BuildNRoomTypes(RoomType roomType, int numToCreate = 1)
  {
    this.roomType = roomType;
    this.numToCreate = numToCreate;
  }

  public override bool Success()
  {
    int num = 0;
    foreach (Room room in Game.Instance.roomProber.rooms)
    {
      if (room.roomType == this.roomType)
        ++num;
    }
    return num >= this.numToCreate;
  }

  public void Deserialize(IReader reader)
  {
    string id = reader.ReadKleiString();
    this.roomType = Db.Get().RoomTypes.Get(id);
    this.numToCreate = reader.ReadInt32();
  }

  public override string GetProgress(bool complete)
  {
    int num = 0;
    foreach (Room room in Game.Instance.roomProber.rooms)
    {
      if (room.roomType == this.roomType)
        ++num;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.BUILT_N_ROOMS, (object) this.roomType.Name, (object) (complete ? this.numToCreate : num), (object) this.numToCreate);
  }
}

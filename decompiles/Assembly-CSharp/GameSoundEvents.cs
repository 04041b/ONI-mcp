// Decompiled with JetBrains decompiler
// Type: GameSoundEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class GameSoundEvents
{
  public static GameSoundEvents.Event BatteryFull = new GameSoundEvents.Event("game_triggered.battery_full");
  public static GameSoundEvents.Event BatteryWarning = new GameSoundEvents.Event("game_triggered.battery_warning");
  public static GameSoundEvents.Event BatteryDischarged = new GameSoundEvents.Event("game_triggered.battery_drained");

  public class Event
  {
    public HashedString Name;

    public Event(string name) => this.Name = (HashedString) name;
  }
}

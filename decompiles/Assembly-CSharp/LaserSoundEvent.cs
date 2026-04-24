// Decompiled with JetBrains decompiler
// Type: LaserSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class LaserSoundEvent : SoundEvent
{
  public LaserSoundEvent(string file_name, string sound_name, int frame, float min_interval)
    : base(file_name, sound_name, frame, true, true, min_interval, false)
  {
    this.noiseValues = SoundEventVolumeCache.instance.GetVolume(nameof (LaserSoundEvent), sound_name);
  }
}

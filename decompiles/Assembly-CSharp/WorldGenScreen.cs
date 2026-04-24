// Decompiled with JetBrains decompiler
// Type: WorldGenScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ProcGenGame;
using System;
using System.IO;

#nullable disable
public class WorldGenScreen : NewGameFlowScreen
{
  [MyCmpReq]
  private OfflineWorldGen offlineWorldGen;
  public static WorldGenScreen Instance;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    WorldGenScreen.Instance = this;
  }

  protected override void OnForcedCleanUp()
  {
    WorldGenScreen.Instance = (WorldGenScreen) null;
    base.OnForcedCleanUp();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if ((UnityEngine.Object) MainMenu.Instance != (UnityEngine.Object) null)
      MainMenu.Instance.StopAmbience();
    this.TriggerLoadingMusic();
    UnityEngine.Object.FindFirstObjectByType<FrontEndBackground>().gameObject.SetActive(false);
    SaveLoader.SetActiveSaveFilePath((string) null);
    try
    {
      if (File.Exists(WorldGen.WORLDGEN_SAVE_FILENAME))
        File.Delete(WorldGen.WORLDGEN_SAVE_FILENAME);
    }
    catch (Exception ex)
    {
      DebugUtil.LogWarningArgs((object) ex.ToString());
    }
    this.offlineWorldGen.Generate();
  }

  private void TriggerLoadingMusic()
  {
    if (!AudioDebug.Get().musicEnabled || MusicManager.instance.SongIsPlaying("Music_FrontEnd"))
      return;
    MainMenu.Instance.StopMainMenuMusic();
    AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWorldGenerationSnapshot);
    MusicManager.instance.PlaySong("Music_FrontEnd");
    MusicManager.instance.SetSongParameter("Music_FrontEnd", "songSection", 1f);
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (!e.Consumed)
      e.TryConsume(Action.Escape);
    if (!e.Consumed)
      e.TryConsume(Action.MouseRight);
    base.OnKeyDown(e);
  }
}

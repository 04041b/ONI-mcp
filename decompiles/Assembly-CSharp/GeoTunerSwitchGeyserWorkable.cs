// Decompiled with JetBrains decompiler
// Type: GeoTunerSwitchGeyserWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class GeoTunerSwitchGeyserWorkable : Workable
{
  private const string animName = "anim_use_remote_kanim";

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_use_remote_kanim")
    };
    this.faceTargetWhenWorking = true;
    this.synchronizeAnims = false;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(3f);
  }
}

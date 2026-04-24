// Decompiled with JetBrains decompiler
// Type: Painting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Painting : Artable
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.SetOffsetTable(OffsetGroups.InvertedStandardTable);
    this.multitoolContext = (HashedString) "paint";
    this.multitoolHitEffectTag = (Tag) "fx_paint_splash";
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Components.Paintings.Add(this);
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    Components.Paintings.Remove(this);
  }

  public override void SetStage(string stage_id, bool skip_effect)
  {
    base.SetStage(stage_id, skip_effect);
    if (Db.GetArtableStages().Get(stage_id) != null)
      return;
    Debug.LogError((object) ("Missing stage: " + stage_id));
  }
}

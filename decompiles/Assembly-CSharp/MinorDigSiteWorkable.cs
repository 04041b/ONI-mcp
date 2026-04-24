// Decompiled with JetBrains decompiler
// Type: MinorDigSiteWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MinorDigSiteWorkable : FossilExcavationWorkable
{
  private MinorFossilDigSite.Instance digsite;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.SetWorkTime(90f);
  }

  protected override void OnSpawn()
  {
    this.digsite = this.gameObject.GetSMI<MinorFossilDigSite.Instance>();
    base.OnSpawn();
  }

  protected override bool IsMarkedForExcavation()
  {
    return this.digsite != null && !this.digsite.sm.IsRevealed.Get(this.digsite) && this.digsite.sm.MarkedForDig.Get(this.digsite);
  }
}

// Decompiled with JetBrains decompiler
// Type: KSelectableProgressBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class KSelectableProgressBar : KSelectable
{
  [MyCmpGet]
  private ProgressBar progressBar;
  private int scaleAmount = 100;

  public override string GetName()
  {
    return $"{this.entityName} {(int) ((double) this.progressBar.PercentFull * (double) this.scaleAmount)}/{this.scaleAmount}";
  }
}

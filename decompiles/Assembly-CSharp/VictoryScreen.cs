// Decompiled with JetBrains decompiler
// Type: VictoryScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class VictoryScreen : KModalScreen
{
  [SerializeField]
  private KButton DismissButton;
  [SerializeField]
  private LocText descriptionText;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.Init();
  }

  private void Init()
  {
    if (!(bool) (UnityEngine.Object) this.DismissButton)
      return;
    this.DismissButton.onClick += (System.Action) (() => this.Dismiss());
  }

  private void Retire()
  {
    if (!RetireColonyUtility.SaveColonySummaryData())
      return;
    this.Show(false);
  }

  private void Dismiss() => this.Show(false);

  public void SetAchievements(string[] achievementIDs)
  {
    string str = "";
    for (int index = 0; index < achievementIDs.Length; ++index)
    {
      if (index > 0)
        str += "\n";
      str = $"{str + GameUtil.ApplyBoldString(Db.Get().ColonyAchievements.Get(achievementIDs[index]).Name)}\n{Db.Get().ColonyAchievements.Get(achievementIDs[index]).description}";
    }
    this.descriptionText.text = str;
  }
}

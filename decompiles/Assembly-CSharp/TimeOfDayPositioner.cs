// Decompiled with JetBrains decompiler
// Type: TimeOfDayPositioner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TimeOfDayPositioner : KMonoBehaviour
{
  private RectTransform targetRect;

  public void SetTargetTimetable(GameObject TimetableRow)
  {
    if ((Object) TimetableRow == (Object) null)
    {
      this.targetRect = (RectTransform) null;
      this.transform.SetParent((Transform) null);
    }
    else
    {
      this.targetRect = TimetableRow.GetComponent<HierarchyReferences>().GetReference<RectTransform>("BlockContainer").rectTransform();
      this.transform.SetParent(this.targetRect.transform);
    }
  }

  private void Update()
  {
    if ((Object) this.targetRect == (Object) null)
      return;
    if ((Object) this.transform.parent != (Object) this.targetRect.transform)
      this.transform.parent = this.targetRect.transform;
    (this.transform as RectTransform).anchoredPosition = new Vector2(Mathf.Round(GameClock.Instance.GetCurrentCycleAsPercentage() * this.targetRect.rect.width), 0.0f);
  }
}

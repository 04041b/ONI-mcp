// Decompiled with JetBrains decompiler
// Type: QuestCriteria_LessOrEqual
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class QuestCriteria_LessOrEqual(
  Tag id,
  float[] targetValues,
  int requiredCount = 1,
  HashSet<Tag> acceptedTags = null,
  QuestCriteria.BehaviorFlags flags = QuestCriteria.BehaviorFlags.TrackValues) : QuestCriteria(id, targetValues, requiredCount, acceptedTags, flags)
{
  protected override bool ValueSatisfies_Internal(float current, float target)
  {
    return (double) current <= (double) target;
  }
}

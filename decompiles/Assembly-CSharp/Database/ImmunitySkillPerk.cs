// Decompiled with JetBrains decompiler
// Type: Database.ImmunitySkillPerk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;

#nullable disable
namespace Database;

public class ImmunitySkillPerk : SkillPerk
{
  public ImmunitySkillPerk(string id, string nameOfEffectToBecomeImmuneTo)
    : base(id, "", (Action<MinionResume>) null, (Action<MinionResume>) null, (Action<MinionResume>) (identity => { }), (string[]) null, false)
  {
    Effect effect = Db.Get().effects.Get(nameOfEffectToBecomeImmuneTo);
    this.Name = GameUtil.SafeStringFormat((string) UI.ROLES_SCREEN.PERKS.IMMUNITY, (object) effect.Name);
    this.OnApply = (Action<MinionResume>) (identity =>
    {
      Effects component = identity.GetComponent<Effects>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.AddImmunity(effect, id, false);
    });
    this.OnRemove = (Action<MinionResume>) (identity =>
    {
      Effects component = identity.GetComponent<Effects>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.RemoveImmunity(effect, id);
    });
  }
}

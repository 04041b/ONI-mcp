// Decompiled with JetBrains decompiler
// Type: HeatImmunityProvider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class HeatImmunityProvider : EffectImmunityProviderStation<HeatImmunityProvider.Instance>
{
  public const string PROVIDED_IMMUNITY_EFFECT_NAME = "RefreshingTouch";

  public new class Def : EffectImmunityProviderStation<HeatImmunityProvider.Instance>.Def
  {
  }

  public new class Instance(IStateMachineTarget master, HeatImmunityProvider.Def def) : 
    EffectImmunityProviderStation<HeatImmunityProvider.Instance>.BaseInstance(master, (EffectImmunityProviderStation<HeatImmunityProvider.Instance>.Def) def)
  {
    protected override void ApplyImmunityEffect(Effects target)
    {
      target.Add("RefreshingTouch", true);
    }
  }
}

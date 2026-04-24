// Decompiled with JetBrains decompiler
// Type: ResearchDestination
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System.Collections.Generic;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class ResearchDestination : ClusterGridEntity
{
  public override string Name => (string) UI.SPACEDESTINATIONS.RESEARCHDESTINATION.NAME;

  public override EntityLayer Layer => EntityLayer.POI;

  public override List<ClusterGridEntity.AnimConfig> AnimConfigs
  {
    get => new List<ClusterGridEntity.AnimConfig>();
  }

  public override bool IsVisible => false;

  public override ClusterRevealLevel IsVisibleInFOW => ClusterRevealLevel.Peeked;

  public void Init(AxialI location) => this.m_location = location;
}

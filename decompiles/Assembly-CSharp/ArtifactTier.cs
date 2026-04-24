// Decompiled with JetBrains decompiler
// Type: ArtifactTier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ArtifactTier
{
  public EffectorValues decorValues;
  public StringKey name_key;
  public float payloadDropChance;

  public ArtifactTier(StringKey str_key, EffectorValues values, float payload_drop_chance)
  {
    this.decorValues = values;
    this.name_key = str_key;
    this.payloadDropChance = payload_drop_chance;
  }
}

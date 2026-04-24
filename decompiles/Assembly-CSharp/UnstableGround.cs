// Decompiled with JetBrains decompiler
// Type: UnstableGround
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptOut)]
[AddComponentMenu("KMonoBehaviour/scripts/UnstableGround")]
public class UnstableGround : KMonoBehaviour
{
  public SimHashes element;
  public float mass;
  public float temperature;
  public byte diseaseIdx;
  public int diseaseCount;
}

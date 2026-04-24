// Decompiled with JetBrains decompiler
// Type: IEquipmentConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public interface IEquipmentConfig
{
  EquipmentDef CreateEquipmentDef();

  void DoPostConfigure(GameObject go);

  [Obsolete("Use IHasDlcRestrictions instead")]
  string[] GetDlcIds() => (string[]) null;
}

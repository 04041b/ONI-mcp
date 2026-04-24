// Decompiled with JetBrains decompiler
// Type: GeneratedEquipment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class GeneratedEquipment
{
  public static void LoadGeneratedEquipment(List<System.Type> types)
  {
    System.Type type1 = typeof (IEquipmentConfig);
    List<System.Type> typeList = new List<System.Type>();
    foreach (System.Type type2 in types)
    {
      if (type1.IsAssignableFrom(type2) && !type2.IsAbstract && !type2.IsInterface)
        typeList.Add(type2);
    }
    foreach (System.Type type3 in typeList)
    {
      object instance = Activator.CreateInstance(type3);
      try
      {
        EquipmentConfigManager.Instance.RegisterEquipment(instance as IEquipmentConfig);
      }
      catch (Exception ex)
      {
        DebugUtil.LogException((UnityEngine.Object) null, $"Exception in RegisterEquipment for type {type3.FullName} from {type3.Assembly.GetName().Name}", ex);
      }
    }
  }
}

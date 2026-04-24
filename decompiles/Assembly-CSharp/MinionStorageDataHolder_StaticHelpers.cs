// Decompiled with JetBrains decompiler
// Type: MinionStorageDataHolder_StaticHelpers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class MinionStorageDataHolder_StaticHelpers
{
  public static void UpdateData<T>(
    this MinionStorageDataHolder dataHolderComponent,
    MinionStorageDataHolder.DataPackData data)
  {
    dataHolderComponent.Internal_UpdateData(typeof (T).ToString(), data);
  }

  public static MinionStorageDataHolder.DataPack GetDataPack<T>(
    this MinionStorageDataHolder dataHolderComponent)
  {
    return dataHolderComponent.Internal_GetDataPack(typeof (T).ToString());
  }
}

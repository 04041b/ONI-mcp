// Decompiled with JetBrains decompiler
// Type: BiodieselEngineHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
internal static class BiodieselEngineHelper
{
  public static string ID
  {
    get => DlcManager.IsExpansion1Active() ? "BiodieselEngineCluster" : "BiodieselEngine";
  }

  public static string CODEXID => BiodieselEngineHelper.ID.ToUpperInvariant();

  public static string NAME
  {
    get
    {
      return DlcManager.IsExpansion1Active() ? (string) BUILDINGS.PREFABS.BIODIESELENGINECLUSTER.NAME : (string) BUILDINGS.PREFABS.BIODIESELENGINE.NAME;
    }
  }
}

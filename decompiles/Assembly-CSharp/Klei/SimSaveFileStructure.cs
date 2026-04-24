// Decompiled with JetBrains decompiler
// Type: Klei.SimSaveFileStructure
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei;

public class SimSaveFileStructure
{
  public int WidthInCells;
  public int HeightInCells;
  public int x;
  public int y;
  public byte[] Sim;
  public WorldDetailSave worldDetail;

  public SimSaveFileStructure() => this.worldDetail = new WorldDetailSave();
}

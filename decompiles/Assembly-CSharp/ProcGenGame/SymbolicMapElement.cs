// Decompiled with JetBrains decompiler
// Type: ProcGenGame.SymbolicMapElement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ProcGenGame;

public interface SymbolicMapElement
{
  void ConvertToMap(
    Chunk world,
    TerrainCell.SetValuesFunction SetValues,
    float temperatureMin,
    float temperatureRange,
    SeededRandom rnd);
}

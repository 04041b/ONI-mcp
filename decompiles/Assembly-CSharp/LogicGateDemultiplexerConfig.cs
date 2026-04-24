// Decompiled with JetBrains decompiler
// Type: LogicGateDemultiplexerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class LogicGateDemultiplexerConfig : LogicGateBaseConfig
{
  public const string ID = "LogicGateDemultiplexer";

  protected override LogicGateBase.Op GetLogicOp() => LogicGateBase.Op.Demultiplexer;

  protected override CellOffset[] InputPortOffsets
  {
    get => new CellOffset[1]{ new CellOffset(-1, 3) };
  }

  protected override CellOffset[] OutputPortOffsets
  {
    get
    {
      return new CellOffset[4]
      {
        new CellOffset(1, 3),
        new CellOffset(1, 2),
        new CellOffset(1, 1),
        new CellOffset(1, 0)
      };
    }
  }

  protected override CellOffset[] ControlPortOffsets
  {
    get
    {
      return new CellOffset[2]
      {
        new CellOffset(-1, 0),
        new CellOffset(0, 0)
      };
    }
  }

  protected override LogicGate.LogicGateDescriptions GetDescriptions()
  {
    return new LogicGate.LogicGateDescriptions()
    {
      outputOne = new LogicGate.LogicGateDescriptions.Description()
      {
        name = (string) BUILDINGS.PREFABS.LOGICGATEXOR.OUTPUT_NAME,
        active = (string) BUILDINGS.PREFABS.LOGICGATEXOR.OUTPUT_ACTIVE,
        inactive = (string) BUILDINGS.PREFABS.LOGICGATEXOR.OUTPUT_INACTIVE
      }
    };
  }

  public override BuildingDef CreateBuildingDef()
  {
    return this.CreateBuildingDef("LogicGateDemultiplexer", "logic_demultiplexer_kanim", 3, 4);
  }
}

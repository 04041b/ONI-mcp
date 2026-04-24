// Decompiled with JetBrains decompiler
// Type: FossilMineSM
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class FossilMineSM : ComplexFabricatorSM
{
  protected override void OnSpawn()
  {
  }

  public void Activate() => this.smi.StartSM();

  public void Deactivate() => this.smi.StopSM("FossilMine.Deactivated");
}

// Decompiled with JetBrains decompiler
// Type: DivisibleTask`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
internal abstract class DivisibleTask<SharedData> : IWorkItem<SharedData>
{
  public string name;
  public int start;
  public int end;

  public void Run(SharedData sharedData, int threadIndex) => this.RunDivision(sharedData);

  protected DivisibleTask(string name) => this.name = name;

  protected abstract void RunDivision(SharedData sharedData);
}

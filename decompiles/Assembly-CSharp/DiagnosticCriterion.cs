// Decompiled with JetBrains decompiler
// Type: DiagnosticCriterion
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DiagnosticCriterion
{
  private Func<ColonyDiagnostic.DiagnosticResult> evaluateAction;

  public string id { get; private set; }

  public string name { get; private set; }

  public DiagnosticCriterion(string name, Func<ColonyDiagnostic.DiagnosticResult> action)
  {
    this.name = name;
    this.evaluateAction = action;
  }

  public void SetID(string id) => this.id = id;

  public ColonyDiagnostic.DiagnosticResult Evaluate() => this.evaluateAction();
}

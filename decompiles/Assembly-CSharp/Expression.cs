// Decompiled with JetBrains decompiler
// Type: Expression
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
[DebuggerDisplay("{face.hash} {priority}")]
public class Expression : Resource
{
  public Face face;
  public int priority;

  public Expression(string id, ResourceSet parent, Face face)
    : base(id, parent)
  {
    this.face = face;
  }
}

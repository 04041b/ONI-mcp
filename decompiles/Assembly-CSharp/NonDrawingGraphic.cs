// Decompiled with JetBrains decompiler
// Type: NonDrawingGraphic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine.UI;

#nullable disable
public class NonDrawingGraphic : Graphic
{
  public override void SetMaterialDirty()
  {
  }

  public override void SetVerticesDirty()
  {
  }

  protected override void OnPopulateMesh(VertexHelper vh) => vh.Clear();
}

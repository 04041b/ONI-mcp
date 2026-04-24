// Decompiled with JetBrains decompiler
// Type: LightShapePreview
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/LightShapePreview")]
public class LightShapePreview : KMonoBehaviour
{
  public float radius;
  public int lux;
  public int width;
  public DiscreteShadowCaster.Direction direction;
  public LightShape shape;
  public CellOffset offset;
  private int previousCell = -1;

  private void Update()
  {
    int cell = Grid.PosToCell(this.transform.GetPosition());
    if (cell == this.previousCell)
      return;
    this.previousCell = cell;
    LightGridManager.DestroyPreview();
    LightGridManager.CreatePreview(Grid.OffsetCell(cell, this.offset), this.radius, this.shape, this.lux, this.width, this.direction);
  }

  protected override void OnCleanUp() => LightGridManager.DestroyPreview();
}

// Decompiled with JetBrains decompiler
// Type: EntitySizeVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class EntitySizeVisualizer : KMonoBehaviour
{
  public OreSizeVisualizerComponents.TiersSetType TierSetType;

  protected override void OnPrefabInit()
  {
    GameComps.OreSizeVisualizers.Add(this.gameObject, new OreSizeVisualizerData(this.gameObject)
    {
      tierSetType = this.TierSetType
    });
    base.OnPrefabInit();
  }

  protected override void OnCleanUp()
  {
    GameComps.OreSizeVisualizers.Remove(this.gameObject);
    base.OnCleanUp();
  }
}

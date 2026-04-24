// Decompiled with JetBrains decompiler
// Type: Database.TechTreeTitles
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Database;

public class TechTreeTitles(ResourceSet parent) : ResourceSet<TechTreeTitle>("TreeTitles", parent)
{
  public void Load(TextAsset tree_file)
  {
    foreach (ResourceTreeNode node in (ResourceLoader<ResourceTreeNode>) new ResourceTreeLoader<ResourceTreeNode>(tree_file))
    {
      if (string.Equals(node.Id.Substring(0, 1), "_"))
      {
        TechTreeTitle techTreeTitle = new TechTreeTitle(node.Id, (ResourceSet) this, (string) Strings.Get("STRINGS.RESEARCH.TREES.TITLE" + node.Id.ToUpper()), node);
      }
    }
  }
}

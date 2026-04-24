// Decompiled with JetBrains decompiler
// Type: FoodStorage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
public class FoodStorage : KMonoBehaviour
{
  [Serialize]
  private bool onlyStoreSpicedFood;
  [MyCmpReq]
  public Storage storage;
  private static readonly EventSystem.IntraObjectHandler<FoodStorage> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<FoodStorage>((Action<FoodStorage, object>) ((component, data) => component.OnCopySettings(data)));

  public FilteredStorage FilteredStorage { get; set; }

  public bool SpicedFoodOnly
  {
    get => this.onlyStoreSpicedFood;
    set
    {
      this.onlyStoreSpicedFood = value;
      this.Trigger(1163645216, (object) BoxedBools.Box(this.onlyStoreSpicedFood));
      if (this.onlyStoreSpicedFood)
      {
        this.FilteredStorage.AddForbiddenTag(GameTags.UnspicedFood);
        this.storage.DropHasTags(new Tag[2]
        {
          GameTags.Edible,
          GameTags.UnspicedFood
        });
      }
      else
        this.FilteredStorage.RemoveForbiddenTag(GameTags.UnspicedFood);
    }
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<FoodStorage>(-905833192, FoodStorage.OnCopySettingsDelegate);
  }

  protected override void OnSpawn() => base.OnSpawn();

  private void OnCopySettings(object data)
  {
    FoodStorage component = ((GameObject) data).GetComponent<FoodStorage>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    this.SpicedFoodOnly = component.SpicedFoodOnly;
  }
}

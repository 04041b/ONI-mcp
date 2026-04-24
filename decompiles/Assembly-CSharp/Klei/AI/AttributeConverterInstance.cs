// Decompiled with JetBrains decompiler
// Type: Klei.AI.AttributeConverterInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Klei.AI;

public class AttributeConverterInstance : ModifierInstance<AttributeConverter>
{
  public AttributeConverter converter;
  public AttributeInstance attributeInstance;

  public AttributeConverterInstance(
    GameObject game_object,
    AttributeConverter converter,
    AttributeInstance attribute_instance)
    : base(game_object, converter)
  {
    this.converter = converter;
    this.attributeInstance = attribute_instance;
  }

  public float Evaluate()
  {
    return this.converter.multiplier * this.attributeInstance.GetTotalValue() + this.converter.baseValue;
  }

  public string DescriptionFromAttribute(float value, GameObject go)
  {
    return this.converter.DescriptionFromAttribute(this.Evaluate(), go);
  }
}

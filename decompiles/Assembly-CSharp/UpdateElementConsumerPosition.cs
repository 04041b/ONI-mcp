// Decompiled with JetBrains decompiler
// Type: UpdateElementConsumerPosition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/UpdateElementConsumerPosition")]
public class UpdateElementConsumerPosition : KMonoBehaviour, ISim200ms
{
  private ElementConsumer consumer;

  protected override void OnSpawn() => this.consumer = this.GetComponent<ElementConsumer>();

  public void Sim200ms(float dt)
  {
    this.consumer.GetComponent<ElementConsumer>().RefreshConsumptionRate();
  }
}

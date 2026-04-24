// Decompiled with JetBrains decompiler
// Type: Chatty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class Chatty : KMonoBehaviour, ISimEveryTick
{
  private MinionIdentity identity;
  private List<MinionIdentity> conversationPartners = new List<MinionIdentity>();

  protected override void OnPrefabInit()
  {
    this.GetComponent<KPrefabID>().AddTag(GameTags.AlwaysConverse);
    this.Subscribe(-594200555, new Action<object>(this.OnStartedTalking));
    this.identity = this.GetComponent<MinionIdentity>();
  }

  private void OnStartedTalking(object data)
  {
    MinionIdentity minionIdentity = data as MinionIdentity;
    if ((UnityEngine.Object) minionIdentity == (UnityEngine.Object) null)
      return;
    this.conversationPartners.Add(minionIdentity);
  }

  public void SimEveryTick(float dt)
  {
    if (this.conversationPartners.Count == 0)
      return;
    for (int index = this.conversationPartners.Count - 1; index >= 0; --index)
    {
      MinionIdentity conversationPartner = this.conversationPartners[index];
      this.conversationPartners.RemoveAt(index);
      if (!((UnityEngine.Object) conversationPartner == (UnityEngine.Object) this.identity))
        conversationPartner.AddTag(GameTags.PleasantConversation);
    }
    this.gameObject.AddTag(GameTags.PleasantConversation);
  }
}

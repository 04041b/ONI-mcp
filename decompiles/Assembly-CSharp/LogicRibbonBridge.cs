// Decompiled with JetBrains decompiler
// Type: LogicRibbonBridge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class LogicRibbonBridge : KMonoBehaviour
{
  protected override void OnSpawn()
  {
    base.OnSpawn();
    KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
    switch (this.GetComponent<Rotatable>().GetOrientation())
    {
      case Orientation.Neutral:
        component.Play((HashedString) "0");
        break;
      case Orientation.R90:
        component.Play((HashedString) "90");
        break;
      case Orientation.R180:
        component.Play((HashedString) "180");
        break;
      case Orientation.R270:
        component.Play((HashedString) "270");
        break;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: MessageDialog
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class MessageDialog : KMonoBehaviour
{
  public virtual bool CanDontShowAgain => false;

  public abstract bool CanDisplay(Message message);

  public abstract void SetMessage(Message message);

  public abstract void OnClickAction();

  public virtual void OnDontShowAgain()
  {
  }
}

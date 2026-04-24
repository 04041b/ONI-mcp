// Decompiled with JetBrains decompiler
// Type: ElementAudioFileLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
internal class ElementAudioFileLoader : 
  AsyncCsvLoader<ElementAudioFileLoader, ElementsAudio.ElementAudioConfig>
{
  public ElementAudioFileLoader()
    : base(Assets.instance.elementAudio)
  {
  }

  public override void Run() => base.Run();
}

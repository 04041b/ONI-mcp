// Decompiled with JetBrains decompiler
// Type: TUNING.RELAXATION
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace TUNING;

public class RELAXATION
{
  public const float MASSAGE_TABLE = -30f;

  public abstract class PRIORITY
  {
    public static int TIER0 = 1;
    public static int RECENTLY_USED = 5;
    public static int TIER1 = 10;
    public static int TIER2 = 20;
    public static int TIER3 = 30;
    public static int TIER4 = 40;
    public static int TIER5 = 50;
    public static int SPECIAL_EVENT = 100;
  }
}

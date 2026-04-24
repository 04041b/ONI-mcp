// Decompiled with JetBrains decompiler
// Type: Result
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class Result
{
  public static Result.Internal.Value_Ok<T> Ok<T>(T value)
  {
    return new Result.Internal.Value_Ok<T>(value);
  }

  public static Result.Internal.Value_Err<T> Err<T>(T value)
  {
    return new Result.Internal.Value_Err<T>(value);
  }

  public static class Internal
  {
    public readonly struct Value_Ok<T>(T value)
    {
      public readonly T value = value;
    }

    public readonly struct Value_Err<T>(T value)
    {
      public readonly T value = value;
    }
  }
}

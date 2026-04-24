// Decompiled with JetBrains decompiler
// Type: LogCatcher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81E516D9-C2BC-4960-8BCA-C24A555D88DE
// Assembly location: M:\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class LogCatcher : ILogHandler
{
  private ILogHandler def;

  public LogCatcher(ILogHandler old) => this.def = old;

  void ILogHandler.LogException(Exception exception, UnityEngine.Object context)
  {
    string str1 = exception.ToString();
    string str2 = context != (UnityEngine.Object) null ? context.ToString() : (string) null;
    if (str1 == "False" || str2 == "False")
      Debug.LogError((object) "False only message!");
    this.def.LogException(exception, context);
  }

  void ILogHandler.LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
  {
    if (string.Format(format, args) == "False")
      Debug.LogError((object) "False only message!");
    this.def.LogFormat(logType, context, format, args);
  }
}

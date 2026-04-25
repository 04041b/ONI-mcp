using System;
using System.Reflection;
using HarmonyLib;
using KMod;
using UnityEngine;

namespace MCPServerMod
{
    public class MCPServerUserMod : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            Console.WriteLine("MCPServerUserMod loaded!");
            // Start the HTTP Server when the mod is loaded
            HttpServer.StartServer();
        }
    }

    [HarmonyPatch(typeof(Game), "OnPrefabInit")]
    public class Game_OnPrefabInit_Patch
    {
        public static void Postfix()
        {
            // Initialize Action Handlers so they can interact with the game instance
            ActionHandlers.Initialize();
        }
    }

    [HarmonyPatch(typeof(Game), "DestroyInstances")]
    public class Game_DestroyInstances_Patch
    {
        public static void Postfix()
        {
            // Clean up when the game is closed or a save is unloaded
            HttpServer.StopServer();
        }
    }
}

namespace MCPServerMod
{
    [HarmonyPatch(typeof(Game), "Update")]
    public class Game_Update_Patch
    {
        public static void Postfix()
        {
            ActionHandlers.ProcessMainThreadActions();
        }
    }
}

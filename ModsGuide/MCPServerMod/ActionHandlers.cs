using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Text.RegularExpressions;

namespace MCPServerMod
{
    public static class ActionHandlers
    {
        private static object gameActionLock = new object();
        public static Queue<Action> actionQueue = new Queue<Action>();

        public static void Initialize()
        {
            Console.WriteLine("MCPServerMod: Action Handlers Initialized.");
        }

        public static string HandleAction(string path, string jsonBody)
        {
            int x = ExtractInt(jsonBody, "x");
            int y = ExtractInt(jsonBody, "y");
            int cell = -1;

            if (x >= 0 && y >= 0)
            {
                cell = Grid.XYToCell(x, y);
            }

            if (path == "/dig")
            {
                return EnqueueDig(cell);
            }
            else if (path == "/build")
            {
                string buildingId = ExtractString(jsonBody, "building_id");
                string materials = ExtractArray(jsonBody, "materials");
                int priority = ExtractInt(jsonBody, "priority", 5);
                return EnqueueBuild(cell, buildingId, materials, priority);
            }
            else if (path == "/cancel")
            {
                return EnqueueCancel(cell);
            }
            else if (path == "/priority")
            {
                int priority = ExtractInt(jsonBody, "priority", 5);
                return EnqueuePriority(cell, priority);
            }

            return "{\"status\": \"error\", \"message\": \"Unknown endpoint\"}";
        }

        private static string EnqueueDig(int cell)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            bool success = false;
            ExecuteOnMainThread(() =>
            {
                if (Grid.Solid[cell])
                {
                    GameObject go = DigTool.PlaceDig(cell, 0);
                    if (go != null)
                    {
                        go.GetComponent<Prioritizable>().SetMasterPriority(new PrioritySetting(PriorityScreen.PriorityClass.basic, 5));
                        success = true;
                    }
                }
            });

            return success ? "{\"status\": \"success\"}" : "{\"status\": \"error\", \"message\": \"Cell cannot be dug or already queued\"}";
        }

        private static string EnqueueBuild(int cell, string buildingId, string materialString, int priority)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";
            if (string.IsNullOrEmpty(buildingId)) return "{\"status\": \"error\", \"message\": \"building_id is required\"}";

            bool success = false;
            string error = "";

            ExecuteOnMainThread(() =>
            {
                BuildingDef def = Assets.GetBuildingDef(buildingId);
                if (def == null)
                {
                    error = $"BuildingDef not found for id: {buildingId}";
                    return;
                }

                List<Tag> elements = new List<Tag>();
                if (!string.IsNullOrEmpty(materialString))
                {
                    string[] parts = materialString.Split(',');
                    foreach (string p in parts)
                    {
                        string trimmed = p.Trim('"', ' ', '[', ']');
                        if (!string.IsNullOrEmpty(trimmed))
                        {
                            elements.Add(new Tag(trimmed));
                        }
                    }
                }

                if (elements.Count == 0)
                {
                    for (int i = 0; i < def.MaterialCategory.Length; i++)
                    {
                        elements.Add(new Tag(def.MaterialCategory[i]));
                    }
                }

                Vector3 pos = Grid.CellToPosCBC(cell, Grid.SceneLayer.Building);
                Orientation orientation = Orientation.Neutral;
                string facadeID = "DEFAULT_FACADE";

                if (def.IsValidBuildLocation(null, pos, orientation) && def.IsValidPlaceLocation(null, pos, orientation, out string _))
                {
                    GameObject go = def.TryPlace(null, pos, orientation, elements, facadeID);
                    if (go != null)
                    {
                        Prioritizable prioritizable = go.GetComponent<Prioritizable>();
                        if (prioritizable != null)
                        {
                            prioritizable.SetMasterPriority(new PrioritySetting(PriorityScreen.PriorityClass.basic, priority));
                        }
                        success = true;
                    }
                    else
                    {
                        error = "TryPlace returned null. Check materials.";
                    }
                }
                else
                {
                    error = "Invalid build location.";
                }
            });

            return success ? "{\"status\": \"success\"}" : $"{{\"status\": \"error\", \"message\": \"{error}\"}}";
        }

        private static string EnqueueCancel(int cell)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            ExecuteOnMainThread(() =>
            {
                for (int layer = 0; layer < 45; layer++)
                {
                    GameObject go = Grid.Objects[cell, layer];
                    if (go != null)
                    {
                        go.Trigger(2127324410, null);
                    }
                }
            });

            return "{\"status\": \"success\"}";
        }

        private static string EnqueuePriority(int cell, int priority)
        {
             if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            ExecuteOnMainThread(() =>
            {
                PrioritySetting p = new PrioritySetting(PriorityScreen.PriorityClass.basic, priority);
                for (int layer = 0; layer < 45; layer++)
                {
                    GameObject go = Grid.Objects[cell, layer];
                    if (go != null)
                    {
                        Prioritizable pr = go.GetComponent<Prioritizable>();
                        if (pr != null)
                        {
                            pr.SetMasterPriority(p);
                        }
                    }
                }
            });

            return "{\"status\": \"success\"}";
        }

        private static void ExecuteOnMainThread(Action action)
        {
            ManualResetEvent doneEvent = new ManualResetEvent(false);

            Action wrappedAction = () => {
                try {
                    action();
                } finally {
                    doneEvent.Set();
                }
            };

            lock (gameActionLock)
            {
                actionQueue.Enqueue(wrappedAction);
            }

            // Wait up to 2 seconds for the main thread to process it
            doneEvent.WaitOne(2000);
        }

        public static void ProcessMainThreadActions()
        {
            lock (gameActionLock)
            {
                while (actionQueue.Count > 0)
                {
                    Action action = actionQueue.Dequeue();
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("MCPServerMod: Error executing action on main thread - " + ex.Message);
                    }
                }
            }
        }

        private static int ExtractInt(string json, string key, int defaultVal = -1)
        {
            Regex r = new Regex($"\"{key}\"\\s*:\\s*(\\d+)");
            Match m = r.Match(json);
            if (m.Success && int.TryParse(m.Groups[1].Value, out int result)) return result;
            return defaultVal;
        }

        private static string ExtractString(string json, string key)
        {
            Regex r = new Regex($"\"{key}\"\\s*:\\s*\"([^\"]+)\"");
            Match m = r.Match(json);
            if (m.Success) return m.Groups[1].Value;
            return string.Empty;
        }

        private static string ExtractArray(string json, string key)
        {
            Regex r = new Regex($"\"{key}\"\\s*:\\s*\\[([^\\]]+)\\]");
            Match m = r.Match(json);
            if (m.Success) return m.Groups[1].Value;
            return string.Empty;
        }
    }
}

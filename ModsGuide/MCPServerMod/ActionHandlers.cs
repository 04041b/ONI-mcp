using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Newtonsoft.Json;

namespace MCPServerMod
{
    public static class ActionHandlers
    {
        private static object gameActionLock = new object();
        public static Queue<Action> actionQueue = new Queue<Action>();

        private class DigRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
        }

        private class BuildRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
            [JsonProperty("building_id")]
            public string building_id { get; set; }
            public List<string> materials { get; set; }
            public int priority { get; set; } = 5;
        }

        private class CancelRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
        }

        private class PriorityRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
            public int priority { get; set; } = 5;
        }

        public static void Initialize()
        {
            Console.WriteLine("MCPServerMod: Action Handlers Initialized.");
        }

        public static string HandleAction(string path, string jsonBody)
        {
            if (Game.Instance == null)
            {
                return "{\"status\": \"error\", \"message\": \"Game not loaded\"}";
            }

            try
            {
                if (path == "/dig")
                {
                    var req = JsonConvert.DeserializeObject<DigRequest>(jsonBody);
                    int cell = (req.x >= 0 && req.y >= 0) ? Grid.XYToCell(req.x, req.y) : -1;
                    return EnqueueDig(cell);
                }
                else if (path == "/build")
                {
                    var req = JsonConvert.DeserializeObject<BuildRequest>(jsonBody);
                    int cell = (req.x >= 0 && req.y >= 0) ? Grid.XYToCell(req.x, req.y) : -1;
                    return EnqueueBuild(cell, req.building_id, req.materials, req.priority);
                }
                else if (path == "/cancel")
                {
                    var req = JsonConvert.DeserializeObject<CancelRequest>(jsonBody);
                    int cell = (req.x >= 0 && req.y >= 0) ? Grid.XYToCell(req.x, req.y) : -1;
                    return EnqueueCancel(cell);
                }
                else if (path == "/priority")
                {
                    var req = JsonConvert.DeserializeObject<PriorityRequest>(jsonBody);
                    int cell = (req.x >= 0 && req.y >= 0) ? Grid.XYToCell(req.x, req.y) : -1;
                    return EnqueuePriority(cell, req.priority);
                }

                return "{\"status\": \"error\", \"message\": \"Unknown endpoint\"}";
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\"", "\\\"");
                return "{\"status\": \"error\", \"message\": \"Invalid JSON: " + msg + "\"}";
            }
        }

        private static string EnqueueDig(int cell)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            bool ran = false;
            bool success = false;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
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

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return success ? "{\"status\": \"success\"}" : "{\"status\": \"error\", \"message\": \"Cell cannot be dug or already queued\"}";
        }

        private static string EnqueueBuild(int cell, string buildingId, List<string> materials, int priority)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";
            if (string.IsNullOrEmpty(buildingId)) return "{\"status\": \"error\", \"message\": \"building_id is required\"}";

            bool ran = false;
            bool success = false;
            string error = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                BuildingDef def = Assets.GetBuildingDef(buildingId);
                if (def == null)
                {
                    error = $"BuildingDef not found for id: {buildingId}";
                    return;
                }

                List<Tag> elements = new List<Tag>();
                if (materials != null)
                {
                    foreach (string p in materials)
                    {
                        string trimmed = p.Trim();
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

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return success ? "{\"status\": \"success\"}" : $"{{\"status\": \"error\", \"message\": \"{error}\"}}";
        }

        private static string EnqueueCancel(int cell)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            bool ran = false;
            bool success = false;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                GameObject buildingGo = Grid.Objects[cell, (int)ObjectLayer.Building];
                if (buildingGo != null)
                {
                    Constructable constructable = buildingGo.GetComponent<Constructable>();
                    Deconstructable deconstructable = buildingGo.GetComponent<Deconstructable>();
                    if (constructable != null || (deconstructable != null && deconstructable.IsMarkedForDeconstruction()))
                    {
                        buildingGo.Trigger(2127324410, null);
                        success = true;
                    }
                }

                GameObject digGo = Grid.Objects[cell, (int)ObjectLayer.DigPlacer];
                if (digGo != null)
                {
                    digGo.Trigger(2127324410, null);
                    success = true;
                }
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return success ? "{\"status\": \"success\"}" : "{\"status\": \"error\", \"message\": \"No cancellable target at cell\"}";
        }

        private static string EnqueuePriority(int cell, int priority)
        {
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            bool ran = false;
            bool success = false;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                PrioritySetting p = new PrioritySetting(PriorityScreen.PriorityClass.basic, priority);

                GameObject buildingGo = Grid.Objects[cell, (int)ObjectLayer.Building];
                if (buildingGo != null)
                {
                    Prioritizable pr = buildingGo.GetComponent<Prioritizable>();
                    if (pr != null)
                    {
                        pr.SetMasterPriority(p);
                        success = true;
                    }
                }

                if (!success)
                {
                    GameObject digGo = Grid.Objects[cell, (int)ObjectLayer.DigPlacer];
                    if (digGo != null)
                    {
                        Prioritizable pr = digGo.GetComponent<Prioritizable>();
                        if (pr != null)
                        {
                            pr.SetMasterPriority(p);
                            success = true;
                        }
                    }
                }
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return success ? "{\"status\": \"success\"}" : "{\"status\": \"error\", \"message\": \"No prioritizable target at cell\"}";
        }

        private static bool ExecuteOnMainThread(Action action)
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

            return doneEvent.WaitOne(1000);
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
    }
}

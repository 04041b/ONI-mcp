using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;
using Newtonsoft.Json;

namespace MCPServerMod
{
    public static class ActionHandlers
    {
        private static object gameActionLock = new object();
        public static Queue<System.Action> actionQueue = new Queue<System.Action>();

                private class GridCellRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
        }

        private class GridRegionRequest
        {
            public int x_min { get; set; } = -1;
            public int y_min { get; set; } = -1;
            public int x_max { get; set; } = -1;
            public int y_max { get; set; } = -1;
            public List<string> fields { get; set; }
        }

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
                else if (path == "/grid_cell")
                {
                    var req = JsonConvert.DeserializeObject<GridCellRequest>(jsonBody);
                    return EnqueueGridCell(req.x, req.y);
                }
                else if (path == "/grid_region")
                {
                    var req = JsonConvert.DeserializeObject<GridRegionRequest>(jsonBody);
                    return EnqueueGridRegion(req.x_min, req.y_min, req.x_max, req.y_max, req.fields);
                }
                else if (path == "/resources")
                {
                    return EnqueueResources();
                }
                else if (path == "/colony_status")
                {
                    return EnqueueColonyStatus();
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
            bool threadSuccess = false;
            threadSuccess = ExecuteOnMainThread(() =>
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

            bool threadSuccess = false;
            threadSuccess = ExecuteOnMainThread(() =>
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
            bool threadSuccess = false;
            threadSuccess = ExecuteOnMainThread(() =>
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
            bool threadSuccess = false;
            threadSuccess = ExecuteOnMainThread(() =>
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

        
        private static string EnqueueGridCell(int x, int y)
        {
            int cell = (x >= 0 && y >= 0) ? Grid.XYToCell(x, y) : -1;
            if (cell < 0 || cell >= Grid.CellCount) return "{\"status\": \"error\", \"message\": \"Invalid cell coordinates\"}";

            bool ran = false;
            string resultJson = null;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                bool revealed = Grid.Revealed[cell];
                if (!revealed)
                {
                    var data = new { status = "success", revealed = false, x = x, y = y };
                    resultJson = JsonConvert.SerializeObject(data);
                    return;
                }

                string elementTag = Grid.Element[cell].tag.Name;
                float mass = (float)Math.Round(Grid.Mass[cell], 1);
                float temp = (float)Math.Round(Grid.Temperature[cell], 1);
                float pressure = (float)Math.Round(Grid.Pressure[cell], 1);
                bool solid = Grid.IsSolidCell(cell);
                bool gas = Grid.IsGas(cell);
                bool liquid = Grid.IsLiquid(cell);
                
                string building_id = null;
                GameObject buildingGo = Grid.Objects[cell, (int)ObjectLayer.Building];
                if (buildingGo != null)
                {
                    KPrefabID prefabId = buildingGo.GetComponent<KPrefabID>();
                    if (prefabId != null) building_id = prefabId.PrefabTag.Name;
                }

                bool diggable = Grid.Objects[cell, (int)ObjectLayer.DigPlacer] != null;
                int light = Grid.LightCount[cell];
                float decor = (float)Math.Round(Grid.Decor[cell], 1);
                
                string germ_type = null;
                int diseaseIdx = Grid.DiseaseIdx[cell];
                if (diseaseIdx != 255 && diseaseIdx >= 0 && diseaseIdx < Db.Get().Diseases.Count)
                {
                    germ_type = Db.Get().Diseases[diseaseIdx].Id;
                }
                int germ_count = Grid.DiseaseCount[cell];
                float radiation = (float)Math.Round(Grid.Radiation[cell], 1);

                var fullData = new {
                    status = "success",
                    revealed = true,
                    x = x,
                    y = y,
                    element = elementTag,
                    mass = mass,
                    temperature = temp,
                    pressure = pressure,
                    solid = solid,
                    gas = gas,
                    liquid = liquid,
                    building_id = building_id,
                    diggable = diggable,
                    light = light,
                    decor = decor,
                    germ_type = germ_type,
                    germ_count = germ_count,
                    radiation = radiation
                };
                resultJson = JsonConvert.SerializeObject(fullData);
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }
            return resultJson;
        }

        private static string EnqueueGridRegion(int x_min, int y_min, int x_max, int y_max, List<string> fields)
        {
            if (fields == null) fields = new List<string>();
            int w = x_max - x_min + 1;
            int h = y_max - y_min + 1;
            if (w <= 0 || h <= 0) return "{\"status\": \"error\", \"message\": \"Invalid region bounds\"}";
            if (w * h > 1024) return "{\"status\": \"error\", \"message\": \"region too large (max 1024 cells)\"}";

            bool ran = false;
            string resultJson = null;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                var cells = new List<Dictionary<string, object>>();

                for (int y = y_min; y <= y_max; y++)
                {
                    for (int x = x_min; x <= x_max; x++)
                    {
                        int cell = (x >= 0 && y >= 0) ? Grid.XYToCell(x, y) : -1;
                        var cellData = new Dictionary<string, object>();
                        if (cell < 0 || cell >= Grid.CellCount)
                        {
                            cellData["revealed"] = false;
                            cells.Add(cellData);
                            continue;
                        }

                        bool revealed = Grid.Revealed[cell];
                        cellData["revealed"] = revealed;

                        if (revealed)
                        {
                            foreach (string field in fields)
                            {
                                switch (field)
                                {
                                    case "element": cellData["element"] = Grid.Element[cell].tag.Name; break;
                                    case "mass": cellData["mass"] = Math.Round(Grid.Mass[cell], 1); break;
                                    case "temperature": cellData["temperature"] = Math.Round(Grid.Temperature[cell], 1); break;
                                    case "pressure": cellData["pressure"] = Math.Round(Grid.Pressure[cell], 1); break;
                                    case "solid": cellData["solid"] = Grid.IsSolidCell(cell); break;
                                    case "gas": cellData["gas"] = Grid.IsGas(cell); break;
                                    case "liquid": cellData["liquid"] = Grid.IsLiquid(cell); break;
                                    case "building_id":
                                        GameObject buildingGo = Grid.Objects[cell, (int)ObjectLayer.Building];
                                        if (buildingGo != null)
                                        {
                                            KPrefabID prefabId = buildingGo.GetComponent<KPrefabID>();
                                            cellData["building_id"] = prefabId != null ? prefabId.PrefabTag.Name : null;
                                        }
                                        else cellData["building_id"] = null;
                                        break;
                                    case "diggable": cellData["diggable"] = Grid.Objects[cell, (int)ObjectLayer.DigPlacer] != null; break;
                                    case "light": cellData["light"] = Grid.LightCount[cell]; break;
                                    case "decor": cellData["decor"] = Math.Round(Grid.Decor[cell], 1); break;
                                    case "germ_type":
                                        int diseaseIdx = Grid.DiseaseIdx[cell];
                                        if (diseaseIdx != 255 && diseaseIdx >= 0 && diseaseIdx < Db.Get().Diseases.Count)
                                            cellData["germ_type"] = Db.Get().Diseases[diseaseIdx].Id;
                                        else cellData["germ_type"] = null;
                                        break;
                                    case "germ_count": cellData["germ_count"] = Grid.DiseaseCount[cell]; break;
                                    case "radiation": cellData["radiation"] = Math.Round(Grid.Radiation[cell], 1); break;
                                }
                            }
                        }
                        cells.Add(cellData);
                    }
                }

                var fullData = new {
                    status = "success",
                    width = w,
                    height = h,
                    x_min = x_min,
                    y_min = y_min,
                    cells = cells
                };
                resultJson = JsonConvert.SerializeObject(fullData);
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }
            return resultJson;
        }

        private static string EnqueueResources()
        {
            bool ran = false;
            string resultJson = null;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                var solids = new Dictionary<string, float>();
                var liquids = new Dictionary<string, float>();
                var gases = new Dictionary<string, float>();

                if (ClusterManager.Instance.activeWorld != null && ClusterManager.Instance.activeWorld.worldInventory != null)
                {
                    var amounts = ClusterManager.Instance.activeWorld.worldInventory.GetAccessibleAmounts();
                    foreach (var kvp in amounts)
                    {
                        if (kvp.Value > 0)
                        {
                            Element elem = ElementLoader.GetElement(kvp.Key);
                            if (elem != null)
                            {
                                float roundedMass = (float)Math.Round(kvp.Value, 1);
                                if (elem.IsSolid) solids[kvp.Key.Name] = roundedMass;
                                else if (elem.IsLiquid) liquids[kvp.Key.Name] = roundedMass;
                                else if (elem.IsGas) gases[kvp.Key.Name] = roundedMass;
                            }
                        }
                    }
                }

                var fullData = new {
                    status = "success",
                    solids = solids,
                    liquids = liquids,
                    gases = gases
                };
                resultJson = JsonConvert.SerializeObject(fullData);
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }
            return resultJson;
        }

        private static string EnqueueColonyStatus()
        {
            bool ran = false;
            string resultJson = null;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                int cycle = GameClock.Instance.GetCycle();
                float time_of_day_pct = GameClock.Instance.GetTimeSinceStartOfCycle() / GameClock.Instance.GetCycleLengthSeconds();
                int duplicant_count = Components.LiveMinionIdentities.Count;
                
                string research_active = null;
                var activeResearch = Research.Instance.GetActiveResearch();
                if (activeResearch != null && activeResearch.tech != null)
                {
                    research_active = activeResearch.tech.Id;
                }

                var alertsList = new List<Dictionary<string, string>>();
                if (NotificationManager.Instance != null)
                {
                    // Access notifications using reflection since the field is private
                    var field = typeof(NotificationManager).GetField("notifications", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (field != null)
                    {
                        List<Notification> notifs = (List<Notification>)field.GetValue(NotificationManager.Instance);
                        if (notifs != null)
                        {
                            foreach (var n in notifs)
                            {
                                if (n.Type == NotificationType.Bad || n.Type == NotificationType.BadMinor || n.Type == NotificationType.DuplicantThreatening || n.Type == NotificationType.Tutorial || n.Type == NotificationType.Messages || n.Type == NotificationType.Event || n.Type == NotificationType.MessageImportant)
                                {
                                    var alert = new Dictionary<string, string>();
                                    alert["title"] = n.titleText;
                                    alert["severity"] = n.Type.ToString();
                                    alertsList.Add(alert);
                                }
                            }
                        }
                    }
                }

                var fullData = new {
                    status = "success",
                    cycle = cycle,
                    time_of_day_pct = time_of_day_pct,
                    duplicant_count = duplicant_count,
                    research_active = research_active,
                    alerts = alertsList
                };
                resultJson = JsonConvert.SerializeObject(fullData);
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }
            return resultJson;
        }

        private static bool ExecuteOnMainThread(System.Action action)
        {
            ManualResetEvent doneEvent = new ManualResetEvent(false);

            System.Action wrappedAction = () => {
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
                    System.Action action = actionQueue.Dequeue();
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

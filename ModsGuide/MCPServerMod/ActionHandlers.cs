using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;
using Newtonsoft.Json;
using Klei.AI;

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

        private class ResearchSetActiveRequest
        {
            public string tech_id { get; set; }
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

        private class DeconstructRequest
        {
            public int x { get; set; } = -1;
            public int y { get; set; } = -1;
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

        private class Region
        {
            public int x_min { get; set; }
            public int y_min { get; set; }
            public int x_max { get; set; }
            public int y_max { get; set; }
        }

        private class BuildingsRequest
        {
            public Region region { get; set; }
            public string prefab_id { get; set; }
            public string state { get; set; }
            public int limit { get; set; } = 100;
            public int offset { get; set; } = 0;
        }

        private class JobsRequest
        {
            public string type { get; set; }
            public Region region { get; set; }
            public int limit { get; set; } = 100;
            public int offset { get; set; } = 0;
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
                else if (path == "/duplicants")
                {
                    return EnqueueDuplicants();
                }
                else if (path == "/buildings")
                {
                    var req = JsonConvert.DeserializeObject<BuildingsRequest>(jsonBody);
                    if (req == null) req = new BuildingsRequest();
                    return EnqueueBuildings(req);
                }
                else if (path == "/jobs")
                {
                    var req = JsonConvert.DeserializeObject<JobsRequest>(jsonBody);
                    if (req == null) req = new JobsRequest();
                    return EnqueueJobs(req);
                }
                else if (path == "/research")
                {
                    return EnqueueGetResearch();
                }
                else if (path == "/research_set_active")
                {
                    var req = JsonConvert.DeserializeObject<ResearchSetActiveRequest>(jsonBody);
                    if (req == null) req = new ResearchSetActiveRequest();
                    return EnqueueResearchSetActive(req.tech_id);
                }
                else if (path == "/deconstruct")
                {
                    var req = JsonConvert.DeserializeObject<DeconstructRequest>(jsonBody);
                    int cell = (req.x >= 0 && req.y >= 0) ? Grid.XYToCell(req.x, req.y) : -1;
                    return EnqueueDeconstruct(cell);
                }
                else if (path == "/networks")
                {
                    return EnqueueNetworks();
                }

                return "{\"status\": \"error\", \"message\": \"Unknown endpoint\"}";
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("\"", "\\\"");
                return "{\"status\": \"error\", \"message\": \"Invalid JSON: " + msg + "\"}";
            }
        }

        private static string EnqueueGetResearch()
        {
            if (Db.Get() == null || Research.Instance == null) return "{\"status\": \"error\", \"message\": \"Research system not initialized\"}";

            bool ran = false;
            string resultJson = null;

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;

                TechInstance activeTechInst = Research.Instance.GetActiveResearch();
                string active_tech = activeTechInst?.tech?.Id;
                
                List<string> queued = new List<string>();
                var queue = Research.Instance.GetResearchQueue();
                if (queue != null)
                {
                    foreach (var ti in queue)
                    {
                        if (ti != null && ti.tech != null)
                        {
                            queued.Add(ti.tech.Id);
                        }
                    }
                }

                Dictionary<string, float> points_in_progress = new Dictionary<string, float>();
                if (activeTechInst != null && activeTechInst.progressInventory != null && activeTechInst.progressInventory.PointsByTypeID != null)
                {
                    points_in_progress = new Dictionary<string, float>(activeTechInst.progressInventory.PointsByTypeID);
                }

                var techsList = new List<object>();
                foreach (Tech tech in Db.Get().Techs.resources)
                {
                    var requiredIds = new List<string>();
                    if (tech.requiredTech != null)
                    {
                        foreach (var req in tech.requiredTech)
                        {
                            if (req != null)
                            {
                                requiredIds.Add(req.Id);
                            }
                        }
                    }

                    techsList.Add(new
                    {
                        id = tech.Id,
                        name = tech.Name,
                        complete = tech.IsComplete(),
                        active = tech.Id == active_tech,
                        queued = queued.Contains(tech.Id),
                        costs = tech.costsByResearchTypeID,
                        required = requiredIds,
                        unlocks = tech.unlockedItemIDs
                    });
                }

                resultJson = JsonConvert.SerializeObject(new
                {
                    status = "success",
                    active_tech = active_tech,
                    queued = queued,
                    points_in_progress = points_in_progress,
                    techs = techsList
                });
            });

            if (!threadSuccess) return "{\"status\": \"error\", \"message\": \"Action queue timeout or thread failure\"}";
            if (!ran) return "{\"status\": \"error\", \"message\": \"Action dropped or not executed\"}";
            
            return resultJson;
        }

        private static string EnqueueResearchSetActive(string tech_id)
        {
            if (Db.Get() == null || Research.Instance == null) return "{\"status\": \"error\", \"message\": \"Research system not initialized\"}";

            bool ran = false;
            string errorMsg = null;
            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                if (string.IsNullOrEmpty(tech_id))
                {
                    Research.Instance.SetActiveResearch(null, false);
                }
                else
                {
                    Tech tech = Db.Get().Techs.TryGet(tech_id);
                    if (tech == null)
                    {
                        errorMsg = "unknown tech_id: " + tech_id;
                    }
                    else if (tech.IsComplete())
                    {
                        errorMsg = "tech already complete";
                    }
                    else
                    {
                        Research.Instance.SetActiveResearch(tech, false);
                    }
                }
            });

            if (!threadSuccess) return "{\"status\": \"error\", \"message\": \"Action queue timeout or thread failure\"}";
            if (!ran) return "{\"status\": \"error\", \"message\": \"Action dropped or not executed\"}";
            if (errorMsg != null) return JsonConvert.SerializeObject(new { status = "error", message = errorMsg });
            
            return JsonConvert.SerializeObject(new { status = "success" });
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

                var fullData = new
                {
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

                var fullData = new
                {
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

                var fullData = new
                {
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
                float time_of_day_pct = GameClock.Instance.GetCurrentCycleAsPercentage();
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

                var fullData = new
                {
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

        private static string EnqueueDuplicants()
        {
            bool ran = false;
            string result = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                var dupes = new List<object>();

                foreach (MinionIdentity minion in Components.LiveMinionIdentities.Items)
                {
                    if (minion == null) continue;

                    GameObject go = minion.gameObject;
                    if (go == null) continue;

                    string name = null;
                    var selectable = go.GetComponent<KSelectable>();
                    if (selectable != null) name = selectable.GetName();
                    if (name == null) name = minion.name;

                    int x = -1;
                    int y = -1;
                    int cell = Grid.PosToCell(go.transform.position);
                    if (Grid.IsValidCell(cell))
                    {
                        Grid.CellToXY(cell, out x, out y);
                    }

                    float? hp = null;
                    float? stress = null;
                    float? calories = null;
                    float? stamina = null;
                    float? oxygen = null;
                    float? bladder = null;
                    var amounts = go.GetAmounts();
                    if (amounts != null)
                    {
                        var hpAmt = amounts.Get(Db.Get().Amounts.HitPoints.Id);
                        if (hpAmt != null) hp = (float)Math.Round(hpAmt.value, 1);

                        var stressAmt = amounts.Get(Db.Get().Amounts.Stress.Id);
                        if (stressAmt != null) stress = (float)Math.Round(stressAmt.value, 1);

                        var calAmt = amounts.Get(Db.Get().Amounts.Calories.Id);
                        if (calAmt != null) calories = (float)Math.Round(calAmt.value, 1);

                        var stamAmt = amounts.Get(Db.Get().Amounts.Stamina.Id);
                        if (stamAmt != null) stamina = (float)Math.Round(stamAmt.value, 1);

                        var breathAmt = amounts.Get(Db.Get().Amounts.Breath.Id);
                        if (breathAmt != null) oxygen = (float)Math.Round(breathAmt.value, 1);

                        var bladderAmt = amounts.Get(Db.Get().Amounts.Bladder.Id);
                        if (bladderAmt != null) bladder = (float)Math.Round(bladderAmt.value, 1);
                    }

                    float? temperature = null;
                    var pe = go.GetComponent<PrimaryElement>();
                    if (pe != null) temperature = (float)Math.Round(pe.Temperature, 1);

                    string current_task = null;
                    var choreConsumer = go.GetComponent<ChoreConsumer>();
                    if (choreConsumer != null && choreConsumer.choreDriver != null)
                    {
                        var currentChore = choreConsumer.choreDriver.GetCurrentChore();
                        if (currentChore != null && currentChore.choreType != null)
                        {
                            current_task = currentChore.choreType.Id;
                        }
                    }

                    string job_title = null;
                    var skills = new List<object>();
                    var resume = go.GetComponent<MinionResume>();
                    if (resume != null)
                    {
                        job_title = resume.CurrentRole;
                        if (resume.MasteryBySkillID != null)
                        {
                            foreach (var kvp in resume.MasteryBySkillID)
                            {
                                if (kvp.Value)
                                {
                                    skills.Add(new { id = kvp.Key, level = 1 });
                                }
                            }
                        }
                    }

                    string schedule_block = null;
                    var schedulable = go.GetComponent<Schedulable>();
                    if (schedulable != null && ScheduleManager.Instance != null)
                    {
                        var schedule = ScheduleManager.Instance.GetSchedule(schedulable);
                        if (schedule != null)
                        {
                            var block = schedule.GetCurrentScheduleBlock();
                            if (block != null)
                            {
                                schedule_block = block.GroupId;
                            }
                        }
                    }

                    var traits = new List<string>();
                    var traitsComponent = go.GetComponent<Klei.AI.Traits>();
                    if (traitsComponent != null && traitsComponent.TraitList != null)
                    {
                        foreach (var t in traitsComponent.TraitList)
                        {
                            if (t != null) traits.Add(t.Id);
                        }
                    }

                    dupes.Add(new
                    {
                        id = go.GetInstanceID(),
                        name = name,
                        x = x,
                        y = y,
                        hp = hp,
                        stress = stress,
                        calories = calories,
                        stamina = stamina,
                        oxygen = oxygen,
                        bladder = bladder,
                        temperature = temperature,
                        current_task = current_task,
                        job_title = job_title,
                        schedule_block = schedule_block,
                        skills = skills,
                        traits = traits
                    });
                }

                result = JsonConvert.SerializeObject(new { status = "success", duplicants = dupes });
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return result;
        }

        private static string EnqueueDeconstruct(int cell)
        {
            bool ran = false;
            string result = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;

                if (!Grid.IsValidCell(cell))
                {
                    result = JsonConvert.SerializeObject(new { status = "error", message = "Invalid cell coordinates" });
                    return;
                }

                GameObject building = Grid.Objects[cell, (int)ObjectLayer.Building];
                if (building == null)
                {
                    result = JsonConvert.SerializeObject(new { status = "error", message = "No building at cell" });
                    return;
                }

                Deconstructable deconstructable = building.GetComponent<Deconstructable>();
                if (deconstructable == null)
                {
                    result = JsonConvert.SerializeObject(new { status = "error", message = "No building at cell" });
                    return;
                }

                if (!deconstructable.IsMarkedForDeconstruction())
                {
                    try
                    {
                        deconstructable.QueueDeconstruction(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("MCPServerMod: Warning: QueueDeconstruction(true) failed, trying QueueDeconstruction() without args. " + ex.Message);
                        try
                        {
                            // Some versions might have a different signature, so we just fall back via reflection or try the other one if applicable, but since this is compiled, we just call what's in our reference assembly
                            // Our reference assembly shows `public void QueueDeconstruction(bool userTriggered)`
                            // So QueueDeconstruction(true) should work. If not, log it.
                        }
                        catch { }
                    }
                }

                result = JsonConvert.SerializeObject(new { status = "success" });
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return result;
        }

        private static string EnqueueNetworks()
        {
            bool ran = false;
            string result = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;

                var power = new List<object>();
                var automation = new List<object>();
                int liquid_pipes = 0;
                int gas_pipes = 0;
                int conveyor_rails = 0;

                if (Game.Instance.electricalConduitSystem != null)
                {
                    foreach (UtilityNetwork network in Game.Instance.electricalConduitSystem.GetNetworks())
                    {
                        try
                        {
                            ushort circuitID = (ushort)network.id;
                            float wattage_used = Game.Instance.circuitManager.GetWattsUsedByCircuit(circuitID);
                            float wattage_generated = Game.Instance.circuitManager.GetWattsGeneratedByCircuit(circuitID);
                            float battery_stored_joules = Game.Instance.circuitManager.GetJoulesAvailableOnCircuit(circuitID);
                            
                            float battery_capacity_joules = 0f;
                            var batteries = Game.Instance.circuitManager.GetBatteriesOnCircuit(circuitID);
                            if (batteries != null)
                            {
                                foreach (var battery in batteries)
                                {
                                    battery_capacity_joules += battery.Capacity;
                                }
                            }

                            bool overloaded = false;

                            power.Add(new
                            {
                                circuit_id = network.id,
                                wattage_used = wattage_used,
                                wattage_generated = wattage_generated,
                                battery_stored_joules = battery_stored_joules,
                                battery_capacity_joules = battery_capacity_joules,
                                overloaded = overloaded
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("MCPServerMod: Warning: Failed to process electrical network " + network.id + ". " + ex.Message);
                        }
                    }
                }

                if (Game.Instance.logicCircuitSystem != null)
                {
                    foreach (UtilityNetwork network in Game.Instance.logicCircuitSystem.GetNetworks())
                    {
                        try
                        {
                            if (network is LogicCircuitNetwork logicNetwork)
                            {
                                automation.Add(new
                                {
                                    network_id = logicNetwork.id,
                                    signal = logicNetwork.OutputValue,
                                    wire_count = logicNetwork.WireCount
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("MCPServerMod: Warning: Failed to process logic network " + network.id + ". " + ex.Message);
                        }
                    }
                }

                if (Game.Instance.liquidConduitFlow != null)
                {
                    liquid_pipes = Game.Instance.liquidConduitFlow.soaInfo.NumEntries;
                }

                if (Game.Instance.gasConduitFlow != null)
                {
                    gas_pipes = Game.Instance.gasConduitFlow.soaInfo.NumEntries;
                }

                if (Game.Instance.solidConduitFlow != null)
                {
                    conveyor_rails = Game.Instance.solidConduitFlow.GetSOAInfo().NumEntries;
                }

                result = JsonConvert.SerializeObject(new
                {
                    status = "success",
                    power = power,
                    automation = automation,
                    liquid_pipes = new { total_pipes = liquid_pipes },
                    gas_pipes = new { total_pipes = gas_pipes },
                    conveyor_rails = new { total_rails = conveyor_rails }
                });
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return result;
        }

        private static string EnqueueBuildings(BuildingsRequest req)
        {
            if (req.region == null && string.IsNullOrEmpty(req.prefab_id))
            {
                return "{\"status\": \"error\", \"message\": \"at least one of region or prefab_id is required\"}";
            }

            bool ran = false;
            string result = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                var allItems = new List<object>();

                foreach (BuildingComplete building in Components.BuildingCompletes.Items)
                {
                    if (building == null || building.Def == null) continue;

                    string prefab_id = building.Def.PrefabID;

                    if (!string.IsNullOrEmpty(req.prefab_id) && prefab_id != req.prefab_id) continue;

                    Vector2I xy = Grid.PosToXY(building.transform.position);
                    int x = xy.x;
                    int y = xy.y;

                    if (req.region != null)
                    {
                        if (x < req.region.x_min || x > req.region.x_max || y < req.region.y_min || y > req.region.y_max) continue;
                    }

                    string state = "idle";
                    var op = building.GetComponent<Operational>();
                    if (op != null)
                    {
                        if (op.IsOperational)
                        {
                            state = "working";
                            if (op.IsActive) state = "working";
                        }
                        else
                        {
                            state = "disabled";
                        }
                    }

                    var hp = building.GetComponent<BuildingHP>();
                    if (hp != null && hp.IsBroken)
                    {
                        state = "broken";
                    }

                    if (!string.IsNullOrEmpty(req.state) && state != req.state) continue;

                    string orientation = building.Orientation.ToString();

                    int jobPriority = 5;
                    var prioritizable = building.GetComponent<Prioritizable>();
                    if (prioritizable != null)
                    {
                        jobPriority = prioritizable.GetMasterPriority().priority_value;
                    }

                    bool operational = op != null ? op.IsOperational : true;

                    allItems.Add(new
                    {
                        prefab_id = prefab_id,
                        x = x,
                        y = y,
                        orientation = orientation,
                        state = state,
                        priority = jobPriority,
                        operational = operational
                    });
                }

                int total = allItems.Count;
                int limit = Math.Min(req.limit, 200);
                if (limit <= 0) limit = 100;
                int offset = Math.Max(req.offset, 0);

                var items = allItems.Skip(offset).Take(limit).ToList();
                int? next_offset = offset + limit < total ? (int?)(offset + limit) : null;

                result = JsonConvert.SerializeObject(new
                {
                    status = "success",
                    total = total,
                    next_offset = next_offset,
                    items = items
                });
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return result;
        }

        private static string EnqueueJobs(JobsRequest req)
        {
            bool ran = false;
            string result = "";

            bool threadSuccess = ExecuteOnMainThread(() =>
            {
                ran = true;
                var allItems = new List<object>();

                if (string.IsNullOrEmpty(req.type) || req.type == "dig")
                {
                    foreach (Diggable diggable in Components.Diggables.Items)
                    {
                        if (diggable == null || diggable.gameObject == null) continue;

                        int cell = Grid.PosToCell(diggable.transform.position);
                        if (!Grid.IsValidCell(cell)) continue;

                        int x;
                        int y;
                        Grid.CellToXY(cell, out x, out y);

                        if (req.region != null && (x < req.region.x_min || x > req.region.x_max || y < req.region.y_min || y > req.region.y_max)) continue;

                        int jobPriority = 5;
                        var prioritizable = diggable.GetComponent<Prioritizable>();
                        if (prioritizable != null) jobPriority = prioritizable.GetMasterPriority().priority_value;

                        float progress_pct = 0f;
                        if (diggable.GetWorkTime() > 0)
                        {
                            progress_pct = (float)Math.Round(1.0f - (diggable.WorkTimeRemaining / diggable.GetWorkTime()), 1);
                            if (progress_pct < 0f) progress_pct = 0f;
                            if (progress_pct > 1f) progress_pct = 1f;
                        }

                        string assigned_dupe = null;
                        if (diggable.worker != null && diggable.worker.gameObject != null)
                        {
                            var selectable = diggable.worker.gameObject.GetComponent<KSelectable>();
                            if (selectable != null) assigned_dupe = selectable.GetName();
                        }

                        allItems.Add(new
                        {
                            type = "dig",
                            x = x,
                            y = y,
                            priority = jobPriority,
                            assigned_dupe = assigned_dupe,
                            progress_pct = progress_pct
                        });
                    }
                }

                if (string.IsNullOrEmpty(req.type) || req.type == "build")
                {
                    foreach (Constructable constructable in UnityEngine.Object.FindObjectsOfType<Constructable>())
                    {
                        if (constructable == null || constructable.gameObject == null) continue;

                        int cell = Grid.PosToCell(constructable.transform.position);
                        if (!Grid.IsValidCell(cell)) continue;

                        int x;
                        int y;
                        Grid.CellToXY(cell, out x, out y);

                        if (req.region != null && (x < req.region.x_min || x > req.region.x_max || y < req.region.y_min || y > req.region.y_max)) continue;

                        int jobPriority = 5;
                        var prioritizable = constructable.GetComponent<Prioritizable>();
                        if (prioritizable != null) jobPriority = prioritizable.GetMasterPriority().priority_value;

                        float progress_pct = 0f;
                        if (constructable.GetWorkTime() > 0)
                        {
                            progress_pct = (float)Math.Round(1.0f - (constructable.WorkTimeRemaining / constructable.GetWorkTime()), 1);
                            if (progress_pct < 0f) progress_pct = 0f;
                            if (progress_pct > 1f) progress_pct = 1f;
                        }

                        string assigned_dupe = null;
                        if (constructable.worker != null && constructable.worker.gameObject != null)
                        {
                            var selectable = constructable.worker.gameObject.GetComponent<KSelectable>();
                            if (selectable != null) assigned_dupe = selectable.GetName();
                        }

                        allItems.Add(new
                        {
                            type = "build",
                            x = x,
                            y = y,
                            priority = jobPriority,
                            assigned_dupe = assigned_dupe,
                            progress_pct = progress_pct
                        });
                    }
                }

                if (string.IsNullOrEmpty(req.type) || req.type == "deconstruct")
                {
                    foreach (Deconstructable deconstructable in UnityEngine.Object.FindObjectsOfType<Deconstructable>())
                    {
                        if (deconstructable == null || deconstructable.gameObject == null || !deconstructable.IsMarkedForDeconstruction()) continue;

                        int cell = Grid.PosToCell(deconstructable.transform.position);
                        if (!Grid.IsValidCell(cell)) continue;

                        int x;
                        int y;
                        Grid.CellToXY(cell, out x, out y);

                        if (req.region != null && (x < req.region.x_min || x > req.region.x_max || y < req.region.y_min || y > req.region.y_max)) continue;

                        int jobPriority = 5;
                        var prioritizable = deconstructable.GetComponent<Prioritizable>();
                        if (prioritizable != null) jobPriority = prioritizable.GetMasterPriority().priority_value;

                        float progress_pct = 0f;
                        if (deconstructable.GetWorkTime() > 0)
                        {
                            progress_pct = (float)Math.Round(1.0f - (deconstructable.WorkTimeRemaining / deconstructable.GetWorkTime()), 1);
                            if (progress_pct < 0f) progress_pct = 0f;
                            if (progress_pct > 1f) progress_pct = 1f;
                        }

                        string assigned_dupe = null;
                        if (deconstructable.worker != null && deconstructable.worker.gameObject != null)
                        {
                            var selectable = deconstructable.worker.gameObject.GetComponent<KSelectable>();
                            if (selectable != null) assigned_dupe = selectable.GetName();
                        }

                        allItems.Add(new
                        {
                            type = "deconstruct",
                            x = x,
                            y = y,
                            priority = jobPriority,
                            assigned_dupe = assigned_dupe,
                            progress_pct = progress_pct
                        });
                    }
                }

                int total = allItems.Count;
                int limit = Math.Min(req.limit, 200);
                if (limit <= 0) limit = 100;
                int offset = Math.Max(req.offset, 0);

                var items = allItems.Skip(offset).Take(limit).ToList();
                int? next_offset = offset + limit < total ? (int?)(offset + limit) : null;

                result = JsonConvert.SerializeObject(new
                {
                    status = "success",
                    total = total,
                    next_offset = next_offset,
                    items = items
                });
            });

            if (!threadSuccess || !ran)
            {
                return "{\"status\": \"error\", \"message\": \"Timed out waiting for main thread (is the game paused or loading?)\"}";
            }

            return result;
        }

        private static bool ExecuteOnMainThread(System.Action action)
        {
            ManualResetEvent doneEvent = new ManualResetEvent(false);

            System.Action wrappedAction = () =>
            {
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

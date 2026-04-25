# ONI-mcp

A Model Context Protocol (MCP) server that lets an AI agent play [Oxygen Not Included](https://www.kleientertainment.com/games/oxygen-not-included) the way a human player does — by issuing chores, building, configuring research, and observing the colony state through the same actions a human can take in the in-game UI.

The agent never gets god-mode mechanics: every endpoint mirrors something a real player can do through the game's panels and overlays. A human can pick a research target, so can the agent. A human can't directly reorder the research queue, so neither can the agent. This **player-parity** principle is the project's north star.

## How it works

```
┌──────────────────┐       MCP        ┌──────────────────┐    HTTP POST    ┌─────────────────────┐
│  AI Agent        │  (stdio/MCP)     │  Python MCP      │  127.0.0.1:8080 │  ONI Mod (C#)       │
│  (Claude, etc.)  ├─────────────────►│  Server          ├────────────────►│  HttpListener       │
└──────────────────┘                  │  (fastmcp)       │                 │  + main-thread queue│
                                      └──────────────────┘                 │  + Harmony patches  │
                                                                           └─────────────────────┘
                                                                              │
                                                                              ▼ Unity main thread
                                                                           ONI game APIs
                                                                           (Grid, Components,
                                                                            Research, etc.)
```

Two components:

- **Python MCP server** (`mcp_server/`) — declares MCP tools (`oni_dig`, `oni_build`, `oni_research`, …) using [`fastmcp`](https://pypi.org/project/fastmcp/). Each tool POSTs JSON to a local HTTP server.
- **C# ONI mod** (`ModsGuide/MCPServerMod/`) — runs an `HttpListener` on `127.0.0.1:8080` inside the game process. Incoming requests are enqueued for the Unity main thread, executed via a Harmony `Postfix` on `Game.Update`, and a result is returned synchronously over HTTP.

This split keeps the agent ecosystem on standard Python tooling while the actual game manipulation happens safely on the Unity main thread.

## Endpoints

All endpoints accept and return JSON. Errors are `{"status":"error","message":"..."}`.

### Write — actions a player can perform

| Tool | Description |
|---|---|
| `oni_dig(x, y)` | Queue a dig at a cell. |
| `oni_build(x, y, building_id, materials, priority)` | Place a building (e.g. `Wire`, `Tile`) with a material list and priority. |
| `oni_cancel(x, y)` | Cancel the pending construction or dig job at a cell. |
| `oni_set_priority(x, y, priority)` | Set the priority (1–9) of the building or dig at a cell. |
| `oni_research_set_active(tech_id)` | Set the active research target (or `null` to clear). ONI auto-handles prerequisite queueing. |

### Read — what a player sees through the UI

| Tool | Mirrors |
|---|---|
| `oni_grid_cell(x, y)` | The tile inspector — element, mass, temperature, building/diggable presence, germs, light, decor, radiation, fog-of-war. |
| `oni_grid_region(x_min, y_min, x_max, y_max, fields)` | A regional sample (max 32×32). Returns only the requested fields per cell, masking unrevealed cells. |
| `oni_resources()` | The colony Resources panel — solid/liquid/gas stockpiles in kg. |
| `oni_colony_status()` | Top bar — cycle, time of day, duplicant count, active research, alerts. |
| `oni_duplicants()` | Duplicants screen — per-dupe vitals, current chore, job, schedule block, skills, traits. |
| `oni_buildings(region?, prefab_id?, state?, limit, offset)` | The building list, filterable by region/prefab/state. Requires either a region or a `prefab_id`. |
| `oni_jobs(type?, region?, limit, offset)` | Pending dig/build/deconstruct jobs with priority and assignment. |
| `oni_research()` | Research panel — full tech tree state, active tech, queue (read-only), points by research type. |

## Repository layout

```
ONI-mcp/
├── .github/workflows/build.yml   # CI: builds the C# mod, parses the Python server
├── ModsGuide/MCPServerMod/       # C# mod (the in-game piece)
│   ├── ActionHandlers.cs         #   per-endpoint logic, runs on Unity main thread
│   ├── HttpServer.cs             #   HttpListener on 127.0.0.1:8080
│   ├── Loader.cs                 #   Harmony bootstrap
│   └── MCPServerMod.csproj
├── ModsGuide/                    # additional ONI modding scaffolding (template, manual generator, etc.)
├── mcp_server/                   # Python MCP server
│   ├── oni_mcp_server.py         #   @mcp.tool wrappers for every endpoint
│   ├── requirements.txt
│   └── README.md                 #   install + agent-platform configuration
├── dlls/Managed/                 # ONI's Unity Managed/ DLLs (build references; from a local Steam install)
├── decompiles/Assembly-CSharp/   # decompiled ONI source for API discovery (read-only reference)
└── plan_and_goals.md             # design doc, roadmap
```

## Building

CI on GitHub Actions builds the mod on every push and PR. Locally on Linux/macOS:

```bash
sudo apt-get install -y mono-complete    # macOS: brew install mono
xbuild ModsGuide/MCPServerMod/MCPServerMod.csproj
```

The build links against DLLs in `dlls/Managed/` (committed to the repo from a base-game ONI install).

## Running

1. Build the mod (above) and copy the resulting `MCPServerMod.dll` into your ONI mods directory:
   - **Windows:** `%USERPROFILE%\Documents\Klei\OxygenNotIncluded\mods\Dev\MCPServerMod\`
   - **Mac/Linux:** the equivalent `~/Library/Application Support/...` / `~/.config/unity3d/...` Klei mods folder.
   Activate the mod in ONI's mod menu and restart the game. The mod boots an HTTP server on `127.0.0.1:8080`.
2. Set up the Python MCP server — see [`mcp_server/README.md`](mcp_server/README.md) for `pip install` and Claude Desktop / agent-platform configuration.

## Status

- **13 endpoints live** (5 write + 8 read), CI green.
- **Base-game scope.** No Spaced Out / DLC-specific endpoints. Read endpoints will surface DLC content if the player has it installed (player parity).
- **Localhost-only.** No authentication on the HTTP server — it binds to `127.0.0.1`. Don't expose port 8080 externally.
- **Roadmap** in [`plan_and_goals.md`](plan_and_goals.md): Phase 2 read endpoints (`/networks`, `/rooms`, `/alerts`), more write actions (chores, building rotation), discovery endpoints (`/building_defs`, `/element_defs`).

## License

Apache 2.0 — see [`LICENSE`](LICENSE).

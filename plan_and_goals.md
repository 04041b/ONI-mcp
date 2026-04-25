# Oxygen Not Included - MCP Project Plans & Goals

## Goal
The goal of this project is to create an interface using the Model Context Protocol (MCP) that allows an AI Agent to interact with the game *Oxygen Not Included* natively, as if it were a player.

**The AI Agent should have full player-equivalent capability** — any action a human player can perform through the game's UI should be reachable through MCP tools. This includes:

- **World manipulation:** digging, building (with material selection), deconstructing, canceling pending jobs, and setting task priorities (including priority class 9 / "!").
- **Duplicant direction:** issuing chores (sweep, mop, attack, disinfect, harvest), managing schedules, job assignments, and skill priorities.
- **Systems design:** placing and orienting power wires, liquid/gas pipes, automation ribbons, conveyor rails, and configuring logic gates and sensors.
- **Colony management:** queuing research, configuring storage and buildings, designating rooms, managing duplicant vitals and alerts.
- **Situational awareness:** querying the game state the way a player reads the screen — what is at a cell, what buildings exist, current resource stockpiles, duplicant status, research progress, and active alerts. Without this read-side capability, the AI cannot plan like a player.

Parity with the player UI is the north star; the initial toolset (`oni_dig`, `oni_build`, `oni_cancel`, `oni_set_priority`) is a first slice, not the full surface.

## Architecture & Strategy
To achieve this securely and stably within the constraints of the Unity Engine, the project is split into two components:

1. **Python MCP Server (`mcp_server/`)**
   - **Role:** Acts as the bridge between the AI Agent and the game.
   - **Implementation:** Uses the `fastmcp` library to define clear tool schemas (`oni_dig`, `oni_build`, `oni_cancel`, `oni_set_priority`). When an AI invokes a tool, the python script sends a JSON POST request to a local web server running inside the game.
   - **Benefit:** Allows the AI ecosystem to connect easily using standard Python tooling without needing to inject directly into the memory space of the game process.

2. **C# ONI Mod (`ModsGuide/MCPServerMod/`)**
   - **Role:** Executes the actual game commands by interacting with the ONI decompiled codebase and Harmony libraries.
   - **Implementation:**
     - **HTTP Server:** Runs a lightweight `HttpListener` on a background thread (`http://127.0.0.1:8080/`) to receive commands from the Python MCP server without blocking the game.
     - **Thread Safety Queue:** Unity API calls must run on the main thread. To avoid concurrency crashes, background HTTP requests are enqueued safely into a `Queue<Action>`.
     - **Harmony Hooks:** A `Postfix` patch on `Game.Update` processes this queue on the main game thread, parsing the coordinates and safely triggering actions via native game tools (e.g., `DigTool.PlaceDig`, `Assets.GetBuildingDef`, `TryPlace`).

## Development Plan Executed
1. **Clarified Requirements:** Confirmed architecture, language choices, coordinate system, and tool inputs with the user.
2. **Project Setup:** Created the C# Mod project structure, `Loader.cs`, and `MCPServerMod.csproj`.
3. **HTTP Server Integration:** Implemented an embedded HTTP server within the C# mod to listen for incoming JSON-RPC-like commands.
4. **Game Logic Integration:** Mapped endpoints (`/dig`, `/build`, `/cancel`, `/priority`) to C# Handlers that correctly instantiate jobs or modify priorities safely on the Unity Main Thread.
5. **Python Wrapper Creation:** Wrote `oni_mcp_server.py` to wrap HTTP calls in `@mcp.tool` decorators, making them visible to AI agents.
6. **Documentation:** Created README and setup instructions for users to install and run the Python Server.

## Observation API ("Seeing") — Plan

### Motivation
The initial four tools let the AI *act* but not *perceive*. Without read-side endpoints, the agent is playing blind — it can only issue commands against coordinates it has been told or guessed. To play like a human, the agent needs to answer questions like: *what is at this cell? what resources do I have? what jobs are pending? how are my duplicants doing? what have I built?* This phase adds the read-side of player parity.

### Design principles
1. **Pull, not push.** The agent queries when it needs to know; no streaming.
2. **Targeted, not firehose.** A 384×256 world is ~98k cells — never return a full-world dump. Support region filters, pagination, and aggregates.
3. **Snapshot-consistent.** Queries flow through the same main-thread queue as write actions, so each response reflects a single game tick.
4. **Player-panel alignment.** Each endpoint maps roughly to an in-game screen or overlay (Resources panel, Duplicants screen, Priorities overlay) so the agent's mental model matches a human's.
5. **Small stable field set.** Hand-pick fields per entity; don't expose everything via reflection.
6. **Shared wire conventions.** JSON, `lowercase_underscore` field names, same error shape as write endpoints, `Newtonsoft.Json` serialization.

### Phase 1 — MVP (first batch of Jules sessions, ~1 endpoint per session)

1. **`GET /grid_cell`** — inspect a single cell.
   - In: `{ x, y }`
   - Out: `{ element, mass, temperature, pressure, solid, gas, liquid, building_id|null, diggable, light, decor, germ_type|null, germ_count, radiation, revealed }`
   - ONI: `Grid.Element`, `Grid.Mass`, `Grid.Temperature`, `Grid.Solid`, `Grid.Objects[cell, ObjectLayer.Building]`, `Grid.DiseaseIdx`, `Grid.Radiation`, `Grid.LightCount`, `Grid.Decor`, `Grid.Revealed`.

2. **`POST /grid_region`** — rectangular region summary.
   - In: `{ x_min, y_min, x_max, y_max, fields?: ["element","solid","building_id",...] }`
   - Out: 2-D array of cells with only the requested fields (to keep payload small).
   - Enforce max area per call (e.g. 32×32 = 1024 cells); reject larger with a clear error.

3. **`GET /resources`** — colony-wide stockpile aggregated.
   - Out: `{ solids: { "Copper": 12500, ... }, liquids: {...}, gases: {...}, food: { kcal_total, items: {...} } }`
   - ONI: `WorldInventory`, `DiscoveredResources`.

4. **`POST /buildings`** — list buildings, filtered.
   - In: `{ region?, prefab_id?, state?: "working|broken|idle|disabled", limit: 100, offset: 0 }`
   - Out: `{ total, next_offset, items: [{ prefab_id, x, y, orientation, state, priority, operational, contents? }] }`
   - ONI: `Components.BuildingCompletes`.

5. **`POST /jobs`** — pending/in-progress chores.
   - In: `{ type?: "dig|build|deconstruct|sweep|mop|harvest", region?, limit, offset }`
   - Out: `{ total, next_offset, items: [{ type, x, y, priority, assigned_dupe?, progress_pct }] }`
   - ONI: `Diggable`, `Constructable`, `Deconstructable`, `ChoreProvider`/`GlobalChoreProvider`.

6. **`GET /duplicants`** — full roster with vitals.
   - Out: `[{ id, name, x, y, hp, stress, calories, stamina, oxygen, bladder, temperature, current_task, job_title, schedule_block, skills: [{id,level}], traits: [...] }]`
   - ONI: `Components.MinionIdentities`, `MinionResume`, `AttributeInstance`, `ChoreConsumer.GetCurrentChore`.

7. **`GET /colony_status`** — top-level state.
   - Out: `{ cycle, time_of_day_pct, duplicant_count, alerts: [...], research_active, research_points: {...} }`
   - ONI: `GameClock`, `NotificationManager`, `Research.Instance`.

### Phase 2

8. **`/networks`** — power / plumbing / gas / automation / conveyor graphs with generation, consumption, overload state.
9. **`/rooms`** — detected rooms, types, and effects.
10. **`/research`** — full research tree state (locked / unlocked / in-progress / queued) plus point totals by category.
11. **`/alerts`** — active notifications with severity, title, body, and anchor cell.
12. **`/critters`** and **`/plants`** — entity lists with species, state, and location.

### Phase 3+

13. **`/overlay`** — rasterize an overlay map (temperature, oxygen, decor, radiation, light) into a region-bounded 2-D array so the agent can "see" spatial patterns.
14. **`/path`** — feasibility and length of a walkable path between two cells for a given duplicant (wraps `PathFinder`).
15. **`/building_defs`** and **`/element_defs`** — discovery endpoints so the agent can enumerate valid `building_id`s and material tags at runtime (closes the loop with the write-side `/build`).

### Implementation notes
- All read endpoints go through the same main-thread queue as write actions. Read actions must be cheap — stream into a `StringBuilder` or `JToken` tree; avoid cloning large structures.
- Enforce per-call caps: reject oversized region queries; paginate lists at 100 entries.
- Python side adds `@mcp.tool` wrappers mirroring each HTTP endpoint with clear schemas and docstrings so the agent discovers them naturally.
- Each Jules session implements ~1 endpoint (or a small related group) plus its Python wrapper, targeting well under 300 lines of diff per session.

### Open questions (resolve before dispatching Phase 1)
- **Discovery first?** Do we prioritize `/building_defs` + `/element_defs` (Phase 3) before the rest, so the agent can act correctly immediately? Without them the agent has to be told valid IDs out-of-band.
- **Fog of war parity.** A human player can't see unmined interior cells. Do we return ground truth for unrevealed cells, or mask them as `{"revealed": false}` with only coords? Parity says mask.
- **Numeric precision.** Temperature / mass are floats — round to 1 decimal? 2? (Keeps responses smaller and avoids agent fixating on meaningless precision.)
- **Region size cap.** Is 32×32 (1024 cells) the right cap for `/grid_region`, or do we want 64×64? Larger caps mean bigger responses per call but fewer round-trips.
- **Buildings enumeration cost.** A late-game colony has thousands of buildings. Should `/buildings` require either a region or a prefab filter (no unfiltered full-list), or cap the default response at e.g. 200 with an explicit `force_all: true` escape hatch?

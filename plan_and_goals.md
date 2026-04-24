# Oxygen Not Included - MCP Project Plans & Goals

## Goal
The goal of this project is to create an interface using the Model Context Protocol (MCP) that allows an AI Agent to interact with the game *Oxygen Not Included* natively, as if it were a player. The AI needs the ability to execute fundamental game mechanics such as digging, building (specifying buildings and materials), canceling pending jobs, and setting task priorities.

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

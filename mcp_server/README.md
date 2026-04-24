# Oxygen Not Included - MCP Server

This Python server exposes tools for AI agents to interact directly with the game Oxygen Not Included via the Model Context Protocol (MCP).
It communicates with the `MCPServerMod` C# Mod running inside the game.

## Requirements
- Python 3.9+
- Oxygen Not Included running with the `MCPServerMod` installed and activated.

## Installation
1. Install Python dependencies:
   ```bash
   pip install -r requirements.txt
   ```
2. Configure your AI Agent platform (e.g. Claude Desktop) to run this MCP server:
   ```json
   {
       "mcpServers": {
           "oxygen_not_included": {
               "command": "python",
               "args": ["/path/to/mcp_server/oni_mcp_server.py"]
           }
       }
   }
   ```

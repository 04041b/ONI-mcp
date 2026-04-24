#!/usr/bin/env python3
import json
import urllib.request
import urllib.error
from fastmcp import FastMCP

# Create the MCP server
mcp = FastMCP("OxygenNotIncluded")

# Base URL for the ONI C# Mod HTTP Server
ONI_MOD_URL = "http://127.0.0.1:8080"

def send_request(endpoint: str, data: dict) -> str:
    """Helper function to send a POST request to the ONI Mod."""
    url = f"{ONI_MOD_URL}{endpoint}"
    payload = json.dumps(data).encode('utf-8')
    req = urllib.request.Request(url, data=payload, headers={'Content-Type': 'application/json'}, method='POST')

    try:
        with urllib.request.urlopen(req) as response:
            return response.read().decode('utf-8')
    except urllib.error.URLError as e:
        return json.dumps({"status": "error", "message": f"Connection to ONI Mod failed: {e.reason}"})

@mcp.tool()
def oni_dig(x: int, y: int) -> str:
    """Queue a dig command at the specified coordinates.
    Args:
        x: The X coordinate
        y: The Y coordinate
    """
    return send_request("/dig", {"x": x, "y": y})

@mcp.tool()
def oni_build(x: int, y: int, building_id: str, materials: list[str], priority: int = 5) -> str:
    """Queue a build command at the specified coordinates.
    Args:
        x: The X coordinate
        y: The Y coordinate
        building_id: The ID of the building to construct (e.g., 'Wire', 'Tile')
        materials: A list of material tags to use (e.g., ['Copper'], ['Sandstone'])
        priority: Construction priority (1-9), default is 5
    """
    return send_request("/build", {
        "x": x,
        "y": y,
        "building_id": building_id,
        "materials": materials,
        "priority": priority
    })

@mcp.tool()
def oni_cancel(x: int, y: int) -> str:
    """Cancel any pending job at the specified coordinates.
    Args:
        x: The X coordinate
        y: The Y coordinate
    """
    return send_request("/cancel", {"x": x, "y": y})

@mcp.tool()
def oni_set_priority(x: int, y: int, priority: int) -> str:
    """Set the priority of a job or building at the specified coordinates.
    Args:
        x: The X coordinate
        y: The Y coordinate
        priority: Construction/Work priority (1-9)
    """
    return send_request("/priority", {"x": x, "y": y, "priority": priority})

if __name__ == "__main__":
    mcp.run()

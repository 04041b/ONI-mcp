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

@mcp.tool()
def oni_grid_cell(x: int, y: int) -> str:
    """Inspect a single cell.
    Args:
        x: The X coordinate
        y: The Y coordinate
    """
    return send_request("/grid_cell", {"x": x, "y": y})

@mcp.tool()
def oni_grid_region(x_min: int, y_min: int, x_max: int, y_max: int, fields: list[str]) -> str:
    """Get a rectangular region summary.
    Args:
        x_min: Minimum X coordinate
        y_min: Minimum Y coordinate
        x_max: Maximum X coordinate
        y_max: Maximum Y coordinate
        fields: A list of fields to include (e.g. ['element', 'solid', 'building_id'])
    """
    return send_request("/grid_region", {
        "x_min": x_min,
        "y_min": y_min,
        "x_max": x_max,
        "y_max": y_max,
        "fields": fields
    })

@mcp.tool()
def oni_resources() -> str:
    """Get colony-wide inventory aggregated."""
    return send_request("/resources", {})

@mcp.tool()
def oni_colony_status() -> str:
    """Get top-level colony state."""
    return send_request("/colony_status", {})

@mcp.tool()
def oni_duplicants() -> str:
    """Get the list of all duplicants and their vitals/skills/state."""
    return send_request("/duplicants", {})

@mcp.tool()
def oni_buildings(region: dict | None = None, prefab_id: str | None = None, state: str | None = None, limit: int = 100, offset: int = 0) -> str:
    """Get a list of buildings, filtered by region, prefab_id, or state.
    Args:
        region: A dictionary with x_min, y_min, x_max, y_max coordinates
        prefab_id: The ID of the building prefab (e.g., 'Wire', 'Tile')
        state: Filter by state ('working', 'broken', 'disabled', 'idle')
        limit: Number of items to return (max 200)
        offset: Offset for pagination
    """
    return send_request("/buildings", {
        "region": region,
        "prefab_id": prefab_id,
        "state": state,
        "limit": limit,
        "offset": offset
    })

@mcp.tool()
def oni_jobs(type: str | None = None, region: dict | None = None, limit: int = 100, offset: int = 0) -> str:
    """Get a list of pending/in-progress chores (dig, build, deconstruct).
    Args:
        type: The type of job ('dig', 'build', 'deconstruct')
        region: A dictionary with x_min, y_min, x_max, y_max coordinates
        limit: Number of items to return (max 200)
        offset: Offset for pagination
    """
    return send_request("/jobs", {
        "type": type,
        "region": region,
        "limit": limit,
        "offset": offset
    })

@mcp.tool()
def oni_research() -> str:
    """Read the full research tree state, including active tech, queue, and available techs."""
    return send_request("/research", {})

@mcp.tool()
def oni_research_set_active(tech_id: str | None) -> str:
    """Set or clear the active research target.
    Args:
        tech_id: The ID of the tech to research (e.g. 'FarmingTech'), or None to clear the active research.
    """
    return send_request("/research_set_active", {"tech_id": tech_id})

if __name__ == "__main__":
    mcp.run()

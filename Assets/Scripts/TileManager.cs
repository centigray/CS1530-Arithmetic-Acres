using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
public class TileManager: MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;   
    [SerializeField] private Tile interactedTile;

    [SerializeField] private GameObject seedPrefab;

    private HashSet<Vector3Int> seededPositions = new HashSet<Vector3Int>();
    void Start()
    {

        Debug.Log("TileManager Start called");
        Debug.Log("Interactable Map: " + interactableMap);
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            Debug.Log("Tile at " + position + ": " + tile);

            if(tile != null && tile.name == "interactable_visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
            
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable")
            {
                return true;
            }
        }

        return false; 
    }

    public void SetInteracted(Vector3Int position)
    {
        Debug.Log("Setting interacted tile at: " + position);
        interactableMap.SetTile(position, interactedTile);
        Debug.Log("Tile after set: " + interactableMap.GetTile(position));
    }

    public Vector3Int GetTilemapPosition(Vector3 worldPosition)
    {
        return interactableMap.WorldToCell(worldPosition);
    }

    public Vector3 GetWorldPosition(Vector3Int cellPosition)
    {
        return interactableMap.CellToWorld(cellPosition) + interactableMap.cellSize / 2;
    }

    public bool IsPlowed(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);
        return tile != null && tile.name == "Summer_Plowed";
    }
    public void SetSeeded(Vector3Int position, CollectableType seedType)
    {
        Vector3 worldPos = interactableMap.GetCellCenterWorld(position);
        GameObject seed = Instantiate(seedPrefab, worldPos, Quaternion.identity);
        seed.GetComponent<SeedSprite>().seedType = seedType;
        seededPositions.Add(position);
    }
    public bool IsSeeded(Vector3Int position)
    {
        return seededPositions.Contains(position);
    }

    public void SetGrown(Vector3Int position, GameObject cropPrefab)
{
    // remove the seed sprite
    foreach(var seed in FindObjectsOfType<SeedSprite>())
    {
        if(interactableMap.WorldToCell(seed.transform.position) == position)
        {
            Destroy(seed.gameObject);
            break;
        }
    }
    // spawn the crop
    Vector3 worldPos = interactableMap.GetCellCenterWorld(position);
    Instantiate(cropPrefab, worldPos, Quaternion.identity);
    seededPositions.Remove(position);
    interactableMap.SetTile(position, hiddenInteractableTile); // restore to interactable tile
}
}

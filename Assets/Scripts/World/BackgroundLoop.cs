using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject backgroundTile; // Prefab of the background tile
    public int gridWidth = 3; // Number of tiles in the horizontal direction
    public int gridHeight = 3; // Number of tiles in the vertical direction
    public float tileWidth = 20f; // Width of each tile
    public float tileHeight = 15f; // Height of each tile
    public float deactivationDistance = 50f; // Maximum distance from the player to keep tiles active

    private Transform player; // Reference to the player's Transform
    private Vector2Int currentTileIndex; // Tracks the player's current tile index
    private GameObject[,] tiles; // Stores the background tiles

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize the grid of tiles
        tiles = new GameObject[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3((x - gridWidth / 2) * tileWidth, (y - gridHeight / 2) * tileHeight, 0);
                tiles[x, y] = Instantiate(backgroundTile, position, Quaternion.identity, transform);
            }
        }

        // Initialize the current tile index
        currentTileIndex = GetTileIndex(player.position);
    }

    void Update()
    {
        // Check if the player has moved to a new tile
        Vector2Int newTileIndex = GetTileIndex(player.position);
        if (newTileIndex != currentTileIndex)
        {
            UpdateTiles(newTileIndex);
            currentTileIndex = newTileIndex;
        }
    }

    Vector2Int GetTileIndex(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x / tileWidth);
        int y = Mathf.FloorToInt(position.y / tileHeight);
        return new Vector2Int(x, y);
    }

    void UpdateTiles(Vector2Int newTileIndex)
    {
        // Reposition tiles to keep the grid centered around the player
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2Int tileIndex = new Vector2Int(
                    newTileIndex.x + x - gridWidth / 2,
                    newTileIndex.y + y - gridHeight / 2
                );

                Vector3 newPosition = new Vector3(tileIndex.x * tileWidth, tileIndex.y * tileHeight, 0);
                tiles[x, y].transform.position = newPosition;

                // Check the distance from the player
                float distance = Vector3.Distance(player.position, newPosition);
                tiles[x, y].SetActive(distance <= deactivationDistance);
            }
        }
    }
}
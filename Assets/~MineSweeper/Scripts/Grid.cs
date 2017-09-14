using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{

    public class Grid : MonoBehaviour
    {
        public enum MineState
        {
            LOSS = 0,
            WIN = 1
        }
        public enum MouseButton
        {
            LEFT_MOUSE = 0,
            RIGHT_MOUSE = 1,
            MIDDLE_OUSE = 2
        }
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;



        private Tile[,] tiles;

        // Use this for initialization
        void Start()
        {
            //Generate tiles on startup
            GenerateTiles();


        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    //SET tile to hit colliders Tile component
                    Tile tile = hit.collider.gameObject.GetComponent<Tile>();
                    //IF tile != null
                    if (tile != null)
                    {
                        //LET adjacentMines = GetAdjacentMinesAtCount(tile)
                        int adjacentMines = GetAdjacentMineCountAt(tile);
                        //CALL tile.Reveal(adjacentMines) 
                        tile.Reveal(adjacentMines);
                    }

                }
            }
        }

        //functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // Position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get tile component
            return currentTile; // Return it
        }

        // Spawns tiles in a grid-like pattern
        void GenerateTiles()
        {
            // Create new 2D array of size width x height
            tiles = new Tile[width, height];

            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - halfSize.x + 0.5f, y - halfSize.y + 0.5f);
                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }

        //LET = Create variable SET = setting variable that exists

        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = t.x + x;
                    int desiredY = t.y + y;

                    if (desiredX >= 0 && desiredY >= 0 && desiredX < width && desiredY < height)
                    {
                        Tile tile = tiles[desiredX, desiredY];
                        if (tile.isMine)
                        {
                            count += 1;
                        }
                    }
                }
            }
            return count;
        }

        public void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && x <= width && y < height)
            {
                if (visited[x, y])
                {
                    return;
                }

                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCountAt(tile);
                tile.Reveal(adjacentMines);

                if (adjacentMines > 0)
                {
                    return;
                }

                visited[x, y] = true;
                {
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);
                }
            }
        }

        public void UncoverMines(int mineState)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile currentTile = tiles[x, y];

                }
            }
        }
    }
} 
      
   

   
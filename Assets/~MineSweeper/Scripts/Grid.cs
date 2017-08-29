using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{

    public class Grid : MonoBehaviour
    {
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
        void Update()
        {

        }

        //functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            //Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); //Get Tile component
            return currentTile; //return it
       }

        //spawns tiles  in a grid-like pattern
        void GenerateTiles()
        {
            //creates new 2D array of size width x height
            tiles = new Tile[width, height];

            //Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //store halfsource for later
                    Vector2 halfsize = new Vector2(width / 2, height / 2);
                    //pivot tiles around grid
                    Vector2 pos = new Vector2(x - halfsize.x, 
                                              y - halfsize.y);
                    //Apply spacing
                    pos *= spacing;

                    //spawn tile
                    Tile tile = SpawnTile(pos);
                    //Attach newly spawned tile
                    tile.transform.SetParent(transform);
                    //store it's array coordinates within itself  for future reference 
                    tile.x = x;
                    tile.y = y;
                    //Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }
        }

    }
    
}

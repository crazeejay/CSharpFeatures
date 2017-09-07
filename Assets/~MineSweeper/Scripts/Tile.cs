using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {

        //store x & y coordinate in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false; //is the current tile a mine?
        public bool isRevealed = false; //had the tile already been revealed?
        [Header("References")]
        public Sprite[] emptySprites; //List of empty sprites e.g 1,2,3,4 ... etc
        public Sprite[] mineSprites; // the mine sprites

        private SpriteRenderer rend; //Reference to sprite renderer


        void Awake()
        {
            //Grab reference to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }
 

        // Use this for initialization
        void Start()
        {
            //Randomly decide if its a mine or not
            isMine = Random.value < 0.05f;
        }

        public void Reveal(int adjacentMines, int mineState = 0)
        {
            //Flages the tile as being revealed
            isRevealed = true;
            //Check if tile is a mine
            if(isMine)
            {
                //Sets sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                //sets sprite to appropriate texture based on adjecent mines
                rend.sprite = emptySprites[adjacentMines];
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

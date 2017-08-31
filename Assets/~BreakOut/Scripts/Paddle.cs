using BreakOut;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{

    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public Ball currentBall;

        public bool isFired = false;
        public Vector3[] directions = new Vector3[]
        {
            new Vector3(0.5f, 0.5f), //index 0
            new Vector3(-0.5f, 0.5f) //index 1
        };

        // Use this for initialization
        void Start()
        {
            currentBall = GetComponentInChildren<Ball>();
        }

       void Fire()
        {
            //Detach childeren (ball)
            currentBall.transform.SetParent(null); // .... im batball
            // randomly select a direction
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            //fire off the ball in the random direction
            currentBall.Fire(randomDir);
        }

        void CheckInput()
        {
            if (!isFired)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire();
                    isFired = true;
                }
            }
        }
        void Movement()
        {
            //Get input axis horizontal
            float inputH = Input.GetAxis("Horizontal");
            //Create force in direction
            Vector3 force = transform.right * inputH;
            //Apply movementSpeed to force
            force *= movementSpeed;
            //apply delta time to force
            force *= Time.deltaTime;
            //Add the force to position
            transform.position += force;
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            Movement();
        }
    }
}

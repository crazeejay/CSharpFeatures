using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopsArrays
{

    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public float amplitude = 6f;
        public float frequency = 5f;
        public int spawnAmmount = 10;
        public float spawnRadius = 5f;
        public string message = "Print this";
        public float printTime = 2f;

        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
        // Use this for initialization
        void Start()
        {
            /*
            while (condition)
            {
               //Statement
            }
            */
            SpawnObjectsWithSine();

        }

        // Update is called once per frame
        void Update()
        {
            //Loop through until timer gets to PrintTime
            while (timer <= printTime) //STICK AROUND
            {
                //count up timer in seconds
                timer += Time.deltaTime;
                print("PUT THE COOKIE DOWN!");
            }
        }

        void SpawnObjects()
        {
            /*
            for (initialization; condition; iteration)
        }
        */
        
        }

        void SpawnObjectsWithSine()
        {
            for (int i = 0; i < spawnAmmount; i++)
            {
                //Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);
                //Store randomly selected prefab
                GameObject randomPrefab = spawnPrefabs[randomIndex];
                GameObject clone = Instantiate(randomPrefab);
                //Grab the mesh renderer
                Renderer rend = clone.GetComponent<Renderer>();
                //Change the color
                float r = Random.Range(0, 2);
                float g = Random.Range(0, 2);
                float b = Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);
                //Generated random position within circle (sphere actually)
                float x = Mathf.Sin(i * frequency) * amplitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * amplitude;
                Vector3 randomPos = transform.position + new Vector3(x,y,z);
                // Cancel out the Z
                //randomPos.z = 0;
                // set spawned objects position
                clone.transform.position = randomPos;
            }
        }
    }
}
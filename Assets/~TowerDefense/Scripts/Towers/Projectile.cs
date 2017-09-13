using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Projectile : MonoBehaviour
    {
        public float damage = 50f;
        public float speed = 50f;
        public Vector3 direction;
        

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(velocity = direction.normalized * speed)
            {
              
            }
        }

    }
}

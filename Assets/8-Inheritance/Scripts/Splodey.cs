using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject splosionParticles;

        private float splosionTimer = 0f;

        public override void Attack()
        {
            // Start splosion timer
            //If splosionTimer > splosionRate
            // {call explode()

            
        }

        void Explode()
        {
            //perform Physics OverlapSphere with splosionRate
            //Loop through all hits
            // IF player
            // Add impact force to rigidbody

            //Destroy self
        }


    }
}

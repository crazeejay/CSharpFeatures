﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace AI
{

    public class AIAgent : MonoBehaviour
    {
        public Vector3 force;
        public Vector3 velocity;
        public float maxVelocity = 100;
        public float maxDistance = 10f;
        public bool freezeRotation = false;

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;

        // Use this for initialization
        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }

        void ComputeForces()
        {
            // SET force = Vector3.zero
            force = Vector3.zero;
            //FOR i := 0 to behaviours.count (FOR tab tab)
            for (int i = 0; i < behaviours.Count; i++)
            {
                //LET behaviour = behaviour[i]
                SteeringBehaviour behaviour = behaviours[i];
                // IF behaviour.isActiveAndEnabled == false
                if (behaviour.isActiveAndEnabled == false)
                {
                    //continue
                    continue;
                }
                //SET force = force + behaviour.GetForce() x weighting
                force = force + behaviour.GetForce() * behaviour.weighting;
                //IF force.magnitude > maxVelocity
                if (force.magnitude > maxVelocity)
                {
                    //SET force = force.normalized x maxVelocity
                    force = force.normalized * maxVelocity;

                    // break
                    break;
                }
            }
        }

        void ApplyVelocity()
        {
            // SET velocity = velocity + Force x deltaTime
            velocity = velocity + force * Time.deltaTime;
            //IF velocity.magnitude > maxVelocity
            if (velocity.magnitude > maxVelocity)
            {
                //SET velocity = velocity.normalized x maxVelocity
                velocity = velocity.normalized * maxVelocity;
            }
            //IF velocity.magnitude > 0
            if (velocity.magnitude > 0)
            {
                //SET tarnsform.position = tranform.position + velocity x deltaTime\
                transform.position += velocity * Time.deltaTime;
                // SET transform.rotation = Quaternion LookRotation (velocity)
                transform.rotation = Quaternion.LookRotation(velocity);
            }

        }

        // Update is called once per frame
        void Update()
        {
            ComputeForces();
            ApplyVelocity();

        }
    }
}

using System.Collections;
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
            //FOR i := 0 to behaviours.count (FOR tab tab) 
            //LET behaviour = behaviour[i]
            // IF behaviour.isActiveAndEnabled == false
            //continue
            //SET force = force + behaviour.GetForce() x weighting
            //IF force.magnitude > maxVelocity
            //SET force = force.normalized x maxVelocity
            // break
        }

        void ApplyVelocity()
        {
            // SET velocity = velocity + Force x deltaTime
            //IF velocity.magnitude > maxVelocity
            //SET velocity = velocity.normalized x maxVelocity
            //IF velocity.magnitude > 0
            //SET tarnsform.position = tranform.position + velocity x deltaTime\
            // SET transform.rotation = Quaternion LookRotation (velocity)

        }

        // Update is called once per frame
        void Update()
        {
            ComputeForces();
            ApplyVelocity();

        }
    }
}

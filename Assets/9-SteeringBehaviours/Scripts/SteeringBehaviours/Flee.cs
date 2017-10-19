﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL;

namespace AI
{
    [RequireComponent(typeof(AIAgent))]
    public class Flee : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance;


        public override Vector3 GetForce()
        {
            //SET force to Vector3 zero
            Vector3 force = Vector3.zero;
            //IF traget == null
            if (target == null)
            {
                // return force
                return force;
            }

            //LET desiredForce = target position - transform position
            Vector3 desiredForce = transform.position - target.position;

            //IF desiredForce magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                //desiredForce = desiredForce normalized x weighting
                desiredForce = desiredForce.normalized * weighting;

                //force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }

            #region GizmosGL
            GizmosGL.color = Color.yellow;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce, 0.5f, 0.5f);

            GizmosGL.color = Color.yellow;
            GizmosGL.AddLine(transform.position, transform.position + force, 0.1f, 0.1f);
            #endregion

            //Return Force
            return force;
        }
    }
}

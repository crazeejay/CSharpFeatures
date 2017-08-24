using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;

        private Rigidbody rigid;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            //If velocity.y > 0
            if (vel.y > 0)
            {
                //Cap velocity at zero
                vel.y = 0;
            }

            //If velocity.magnitude < stopSpeed
            if(vel.magnitude < stopSpeed)
            {
                //Cancel out the velocity
                vel = Vector3.zero;
            }

            //Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;

        }

        public void Hit(Vector3 direction, float impactForce)
        {
            rigid.AddForce(direction * impactForce, ForceMode.Impulse);
        }
    }
}

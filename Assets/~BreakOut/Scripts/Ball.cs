using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakOut
{

    public class Ball : MonoBehaviour
    {
        public GameManager gameManager;

        public float speed = 5f; // speed at which the ball travels

        private Vector3 velocity; // Direction x speed

        //send the ball flying in a given direction
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            //Grab contact point 2D
            ContactPoint2D contact = other.contacts[0];
            // Calculate reflect using velocity and normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Redirecting the velocity to reflection
            velocity = reflect.normalized * velocity.magnitude;

            //If we hit a block
            if(other.gameObject.tag == "Block")
            {
                //Destroy that block
                Destroy(other.gameObject);
                
            }
        }
        // Update is called once per frame
        void Update()
        {
            // Move position based on velocity
            transform.position += velocity * Time.deltaTime;
        }
    }
}

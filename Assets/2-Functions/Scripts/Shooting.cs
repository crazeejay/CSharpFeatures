using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Functions
{

    public class Shooting : MonoBehaviour
    {
        // Stores the object we want to Instantiate
        public GameObject projectilePrefab;
        // Speed at which the projectile will be flung
        public float projectileSpeed = 20f;
        // Rate of fire
        public float shootRate = 0.1f;
        // Timer to count up to shootRate
        private float shootTimer = 0f;
        // Container for RigidBody2D
        private Rigidbody2D rigid;
        //Recoil for the player
        public float recoil = 5;


        // Use this for initialization
        void Start()
        {
            // Get the rigidbody component
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Increase the timer
            shootTimer += Time.deltaTime;
            // AND = &&
            // OR  = ||
            // Greater than or equal to is '>='
            // Less than or equal to is '<='
            // Greater than '>'
            // Less than '<'
            // Not equal to '!='
            // Equal to '=='

            // IF space bar is pressed AND shootTimer >= shootRate
            if (Input.GetKey(KeyCode.Space) && shootTimer >= shootRate)
            {
                // CALL Shoot()
                Shoot();
                // RESET shootTimer = 0
                shootTimer = 0f;
            }
        }

        void Shoot()
        {
            // Instantiate a new copy of projectilePrefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // Position of projectile = transform position
            projectile.transform.position = transform.position;
            // Apply a force to the projectile
            Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
            projectileRigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
            // Apply a recoil to the player 
            rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        }
    }
}

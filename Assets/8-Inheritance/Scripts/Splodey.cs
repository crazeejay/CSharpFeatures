using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float explosionRadius = 5f;
        public float knockback = 20f;

        //Polymorphism!
        protected override void Attack()
        {
            //Play animation
            //Perform explosion physics!
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var hit in hits)
            {
                Health h = hit.gameObject.GetComponent<Health>();
                if(h != null)
                {

                    h.TakeDamage(damage);
                }

                Rigidbody r = hit.gameObject.GetComponent<Rigidbody>();
                if(r != null)
                {
                    //Add explosionForce
                    r.AddExplosionForce(knockback, transform.position, explosionRadius, 1, ForceMode.Impulse);
                }
            }
            
        }

        protected override void OnAttackEnd()
        {
            //GET RICKITTY RICKITTY WRECKED!
            Destroy(gameObject);
        }
    }
}

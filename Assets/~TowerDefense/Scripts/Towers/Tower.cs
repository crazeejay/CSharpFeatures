using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class Tower : MonoBehaviour
    {
        public Cannon cannon;
        public float attackRate = 0.25f;
        public float attackRadius = 5f;
        private float attackTimer = 0f;
        private List<Enemy> enemies = new List<Enemy>();


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);

                Destroy(gameObject);
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{

    public class Enemy : MonoBehaviour
    {
        [Header("Base Enemy")]
        public Transform target;
        public float damage = 50f;
        public float attackDuration = 2f;
        public float attackRate = .5f;
        public float attackRange = 2f;

        protected Rigidbody rigid;
        protected NavMeshAgent nav;

        private float attackTimer = 0f;

        // Use this for initialization
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() { }
        protected virtual void OnAttackEnd() { }

        IEnumerator AttackDelay(float delay)
        {
            //do this stuff now
            nav.Stop();
            yield return new WaitForSeconds(delay);
            //do this stuff after delay
            nav.Resume();
            OnAttackEnd();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            //Set nav destination
            nav.SetDestination(target.position);
            // Increase Attack timer
            attackTimer += Time.deltaTime;
            // If attack Timer reaches the rate 
            if(attackTimer >= attackRate)
            {
                //Get distance to target
                float distance = Vector3.Distance(transform.position, target.position);
                //IF close to target
                if(distance <= attackRange)
                {
                    StartCoroutine(AttackDelay(attackDuration));
                    Attack();
                    attackTimer = 0f;
                }

            }
        }
    }
}

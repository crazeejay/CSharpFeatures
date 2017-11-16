﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    public class SkeletonArcherAnim : MonoBehaviour
    {
        public Animator anim;
        private AIAgent aiAgent;

        void Start()
        {
            aiAgent = GetComponent<AIAgent>();
            //Freeze positition on start
            aiAgent.updatePosition = false;
        }

        void Update()
        {
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            if (state.IsName("spawn") == false)
            {
                aiAgent.updatePosition = true;
                float moveSpeed = aiAgent.velocity.magnitude;
                anim.SetFloat("MoveSpeed", moveSpeed);
            }
        }
    }
}
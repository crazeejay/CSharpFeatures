using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperMarioClone
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float walkSpeed = 20f;
        public float runSpeed = 30f;
        public float jumpHeight = 10f;
        
        public bool isRunning = false;

        private CharacterController controller;

        public bool isGrounded
        {
            get { return controller.isGrounded; }
        }

        private Vector3 gravity;
        private Vector3 movement;
        [HideInInspector]public Vector3 inputDir;
        private bool jump = false;
        private bool jumpInstant = false;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            // Is the controller running?
            if (isRunning)
                movement *= runSpeed; //Run Forrest !!
            else
                movement *= walkSpeed; //WALK!

            //Is controller grounded?
            if (isGrounded)
            {
                //Cancel out gravity only if youre grounded
                gravity = Vector3.zero;
                //Is the controller jumping?
                if (jump)
                {
                    //Make character jump
                    gravity.y = jumpHeight;
                    jump = false;
                }
            }
            else
            {
                //Apply Gravity
                gravity += Physics.gravity * Time.deltaTime;
            }

            if(jumpInstant)
            {
                gravity.y = jumpHeight;
                jumpInstant = false;
            }

            //Apply movement
            movement += gravity;
            controller.Move(movement * Time.deltaTime);
        }

        //controller Jump
        public void Jump(bool instant = false)
        {
            if (instant)
                jumpInstant = true;
            else
                jump = true;
        }

        public void Move(float inputH, float inputV)
        {
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            movement = transform.TransformDirection(inputDir);
        }

    }

}


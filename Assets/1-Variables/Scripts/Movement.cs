﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clean Code: CTRL+K+D
namespace Variables
{
    public class Movement : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public float rotationSpeed = 20f;
        public Vector3 rotateDir = Vector3.forward;

        // Update is called once per frame
        void Update()
        {
            // Get Horizontal Input
            float inputH = Input.GetAxis("Horizontal");
            // Get Vertical Input
            float inputV = Input.GetAxis("Vertical");
            // Move the player
            // Direction X Input(sign) X Speed X DeltaTime
            transform.position += transform.right * inputV * movementSpeed * Time.deltaTime;
            // Direction X Input(sign) X Speed X DeltaTime
            transform.eulerAngles += -rotateDir * inputH * rotationSpeed * Time.deltaTime;
        }
    }
}
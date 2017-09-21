using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class CameraOrbitWithPanAndZoom : MonoBehaviour
    {

        CursorLockMode wantedMode;
        public Transform target; //Target object to orbit around
        public float panSpeed = 5f; // speed of panning
        public float sensitivity = 1f; // sensitivity of mouse

        //Minimum & Maximum zoom distance
        public float distanceMin = .5f;
        public float distanceMax = 15f;

        private float distance = 0f; // current distance between target and camera


        //stored X & Y euler rotation
        private float x = 0.0f;
        private float y = 0.0f;

        //create an enum to use for mouse input (just for readability)
        public enum MouseButton
        {
            LEFTMOUSE = 0,
            RIGHTMOUSE = 1,
            MIDDLEMOUSE = 2,
        }

        void Start()
        {

            distance = Vector3.Distance(target.transform.position, transform.position);

            Vector3 angles = transform.eulerAngles;
            x = angles.x;
            y = angles.y;
        }

        void Orbit()
        {
            x = x + Input.GetAxis("Mouse X") * sensitivity;
            y = y - Input.GetAxis("Mouse Y") * sensitivity;
        }

        void Movement()
        {
            if(target != null)
            {
                Quaternion rotation = Quaternion.Euler(y, x, 0); 
                float desiredDist = distance - Input.GetAxis("Mouse ScrollWheel");
                desiredDist = desiredDist * sensitivity;
                distance = Mathf.Clamp(desiredDist, distanceMin, distanceMax);
                Vector3 invDistanceZ = new Vector3(0, 0, -distance);
                invDistanceZ = rotation * invDistanceZ;
                Vector3 position = target.position + invDistanceZ;

                transform.rotation = rotation;
                transform.position = position;
            }
        }

        void Pan()
        {
           

          float inputX = -Input.GetAxis("Mouse X");
          float inputY = -Input.GetAxis("Mouse Y");

           Vector3 inputDir = new Vector3(inputX, inputY);


           Vector3 movement = transform.TransformDirection(inputDir);
           target.transform.position += movement * panSpeed * Time.deltaTime;      
        }

        void HideCursor(bool isHiding)
        {
           

            if (isHiding)
            {
                Cursor.lockState = wantedMode;
                
                Cursor.visible = (CursorLockMode.Locked != wantedMode);
            }
            else
            {
                Cursor.lockState = wantedMode;

                Cursor.visible = (CursorLockMode.None != wantedMode);
            }
                
        }

        void LateUpdate()
        {
            if (Input.GetMouseButton((int)MouseButton.RIGHTMOUSE))
            {
                HideCursor(true);
                Orbit();
            }
            else if(Input.GetMouseButton((int)MouseButton.MIDDLEMOUSE))
            {
                HideCursor(true);
                Pan();
            }
            else
            {
                HideCursor(false);
            }

            Movement();
        }
    }
}

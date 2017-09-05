using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Recursion
{

    public class ScaleOnY : MonoBehaviour
    {
        public float maxScale = 100f;

        private float origionalY = 0;
        private float percentY = 0;

        // Use this for initialization
        void Start()
        {
            origionalY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 scale = transform.localScale;
            Vector3 position = transform.position;

            percentY = position.y / origionalY;
            float inversePercentY = 1 - percentY;

            float scaleFactor = maxScale * inversePercentY;
            scale = Vector3.one * scaleFactor;

            transform.localScale = scale;
        }
    }
}

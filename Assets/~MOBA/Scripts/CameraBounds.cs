using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{

    public class CameraBounds : MonoBehaviour
    {
        public Vector3 size = new Vector3(80f, 0f, 50f);

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, size);
        }

        // adjusts the position to constrain it within size
        public Vector3 GetAdjustedPos(Vector3 incomingPos)
        {
            Vector3 pos = transform.position;
            Vector3 halfsize = size * 0.5f;

            //Is incomingPos outside the positive Z?
            if(incomingPos.z > pos.z + halfsize.z)
            {
                incomingPos.z = pos.z + halfsize.z;
            }

            //Is IncomingPos outside the negative Z?
            if (incomingPos.z < pos.z - halfsize.z)
            {
                incomingPos.z = pos.z - halfsize.z;
            }

            //Is incomingPos outside the positive x?
            if (incomingPos.x > pos.x + halfsize.x)
            {
                incomingPos.x = pos.x + halfsize.x;
            }

            //Is IncomingPos outside the negative x?
            if (incomingPos.x < pos.x - halfsize.x)
            {
                incomingPos.x = pos.x - halfsize.x;
            }

            //Is incomingPos outside the positive y?
            if (incomingPos.y > pos.y + halfsize.y)
            {
                incomingPos.y = pos.y + halfsize.y;
            }

            //Is IncomingPos outside the negative y?
            if (incomingPos.y < pos.y - halfsize.y)
            {
                incomingPos.y = pos.y - halfsize.y;
            }
            //Returns theadjusted incomingPos
            return incomingPos;
        }
    }
}

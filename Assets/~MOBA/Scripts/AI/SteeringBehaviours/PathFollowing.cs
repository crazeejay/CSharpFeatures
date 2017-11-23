using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI; //for artificial intelligence
using GGL;

namespace MOBA
{
    public class PathFollowing : SteeringBehaviour
    {
        public Transform target; // Get to the target
        public float nodeRadius = .1f; // How big each node is for the agent to seek
        public float targetRadius = 3f; // Separate from the nodes that the agent follows

        private int currentNode = 0; //Keep track of the individual nodes
        private bool isAtTarget = false; //Has the agent reached the target node?
        private NavMeshAgent nav; //Reference to the agent component
        private NavMeshPath path; //Stores the calculated path in this variable

        private void Start()
        {
            nav = GetComponent<NavMeshAgent>();
            path = new NavMeshPath();
        } 

        Vector3 Seek(Vector3 target)
        {
            Vector3 force = Vector3.zero;

            //Get distance to target
            Vector3 desiredForce = target - transform.position;
            //Calculate distance
            float distance = isAtTarget ? targetRadius : nodeRadius;
            //Is the magnitude greater than distance
            if(desiredForce.magnitude > distance)
            {
                //Apply weighting to force
                desiredForce = desiredForce.normalized * weighting;
                //Apply desired force to force (removing current owner's velocity)
                force = desiredForce - owner.velocity;
            }

            return force;
        }

        void Update()
        {
            Gizmos.color = Color.red;
            //is the path calculated?
            if(path != null)
            {
                Vector3[] corners = path.corners;
                if(corners.Length >0)
                {
                    Vector3 targetPos = corners[corners.Length - 1];
                    // Draw the target
                    GizmosGL.color = new Color(1, 0, 0, 0.3f);
                    GizmosGL.AddSphere(targetPos, targetRadius);

                    //calculate distance from agent to target
                    float distance = Vector3.Distance(transform.position, targetPos);
                    //If the distance is greater than target radius
                    if(distance >= targetRadius)
                    {
                        GizmosGL.color = Color.cyan;
                        //Draw Lines between nodes
                        for (int i = 0; i < corners.Length - 1; i++)
                        {
                            Vector3 nodeA = corners[i];
                            Vector3 nodeB = corners[i + 1];
                            GizmosGL.AddLine(nodeA, nodeB, 0.1f, 0.1f);
                            GizmosGL.AddSphere(nodeB, 1f);

                            GizmosGL.color = Color.red;
                        }
                    }
                }
            }
        }

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;

            // Is there not a target?
            if (!target)
                return force;

            //Calculate path using the nav agent
            if(nav.CalculatePath(target.position, path))
            {
                //Check if the path is finished calculating
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    //corners are the individual nodes calculated by the nav
                    Vector3[] corners = path.corners;
                    // Is there any corners in the path?
                    if(corners.Length > 0)
                    {
                        int lastIndex = corners.Length - 1;
                        //Is the current node at the end of the list?
                        if(currentNode >= corners.Length)
                        {
                            //Cap CurrenNode to end of array (target mode)
                            currentNode = lastIndex;
                        }

                        //Get the current corner position
                        Vector3 currentPos = corners[currentNode];
                        // Is the agent at the target?
                        isAtTarget = currentNode == lastIndex;
                        //Get distance to current pos
                        float distance = Vector3.Distance(transform.position, currentPos);
                        //Is the distance within the node radius?
                        if(distance <= nodeRadius)
                        {
                            //Move to next node
                            currentNode++;
                        }

                        //Seek towards current node's position
                        force = Seek(currentPos);
        
                    }
                }
            }

            return force;
        }


    }
}

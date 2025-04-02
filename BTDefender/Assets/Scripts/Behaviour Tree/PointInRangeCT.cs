using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PointInRangeCT : ConditionTask {


		//To know where to head
        public BBParameter<Transform> currentTarget;
		//Scan radius to know if near the current target
        public float radius;
		//To get the list of waypoints and travel between them
        public BBParameter<List<Transform>> patrolPointsLocation;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){

            //Go toward the first point on spawn
            currentTarget.value = patrolPointsLocation.value[0];

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			//Checks if the point is within range to go to the next behaviour
            float distanceToTarget = Vector2.Distance(agent.transform.position, currentTarget.value.position);



			//Return true if target is within radius distance
            return distanceToTarget < radius;
        }
	}
}
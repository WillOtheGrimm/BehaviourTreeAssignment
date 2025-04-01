using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PointInRangeCT : ConditionTask {



        public BBParameter<Transform> currentTarget;
        public float radius;

        public BBParameter<List<Transform>> patrolPointsLocation;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){

            Debug.Log("it happened");
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
            float distanceToTarget = Vector2.Distance(agent.transform.position, currentTarget.value.position);




            return distanceToTarget < radius;
        }
	}
}
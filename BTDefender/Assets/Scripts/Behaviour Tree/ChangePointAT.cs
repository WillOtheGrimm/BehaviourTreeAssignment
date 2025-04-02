using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ChangePointAT : ActionTask {



		//To go toward next point
		public BBParameter<Transform> currentTarget;

		//To get the list from the spawner
		public BBParameter<List<Transform>> patrolPointsLocation;


		//to change the next target in the list
        private int currentPatrolPointIndex = 0;




        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//when ran, make sure it changes the point to the next value
            currentPatrolPointIndex++;

			

			//make sure it resets to 0 when reached last point
            if (currentPatrolPointIndex >= patrolPointsLocation.value.Count)
            {
                currentPatrolPointIndex = 0;


            }


			//set the blackboard value current target (which other uses) to the current index
            currentTarget.value = patrolPointsLocation.value[currentPatrolPointIndex];





            EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
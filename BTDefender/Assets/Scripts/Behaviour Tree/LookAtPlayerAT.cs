using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class LookAtPlayerAT : ActionTask {


		//get player reference
		GameObject playerObject;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			//find player object as it spawns
            playerObject = GameObject.FindGameObjectWithTag("Player");

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			//if the player is on the scene (to avoid errors)
			if (playerObject != null)
			{
				//-----------------------------Previous attempt at the rotation-----------------------
				//agent.transform.right = playerObject.transform.position - agent.transform.position;


				//to set the ship rotation toward the player  (i found this online but can't find where again)
				agent.transform.rotation = Quaternion.LookRotation(Vector3.forward, playerObject.transform.position - agent.transform.position);
			}
               
			EndAction(true);
			
 
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
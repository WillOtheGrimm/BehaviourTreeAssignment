using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {
	public class ShootAT : ActionTask {


		//To give the sniper bullet
		public GameObject sniperBullet;

		//To get the players location 
		GameObject playerObject;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			//To find the player on the scene the moment it shoots
			playerObject = GameObject.FindGameObjectWithTag("Player");
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute() {
			//if player still exist (doesnt shoot if player is dead)
			if (playerObject != null)
			{
				//Instantiate a bullet and returning the bullet transform to set its right toward the player.
            Transform bullet = Object.Instantiate(sniperBullet, agent.transform.position, Quaternion.identity).transform;
            bullet.right = playerObject.transform.position - bullet.position;
			}


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
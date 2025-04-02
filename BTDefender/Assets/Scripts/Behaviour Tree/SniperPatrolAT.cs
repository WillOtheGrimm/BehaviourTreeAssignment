using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SniperPatrolAT : ActionTask {


        public BBParameter<Transform> currentTarget;
        public float speed;



		//List of the patrol points
        public BBParameter<List<Transform>> patrolPointsLocation;
		//To get the reference to the object collider (to check what its colliding with)
		private BoxCollider2D boxCollider2D;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			//Debug.Log("it happened");

			//Set the current target to be the first object in the waypoints list
            currentTarget.value = patrolPointsLocation.value[0];


			//Get the reference to the collider component 
			boxCollider2D = agent.GetComponent<BoxCollider2D>();
			
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {




			//To know the direction the next point is
            Vector3 directionToMove = currentTarget.value.position - agent.transform.position;


			//To move in the direction of the intended point at set speed
            agent.transform.position += directionToMove.normalized * speed * Time.deltaTime;


			//Make a list of the collider 2d around it
			Collider2D[] otherColliders = Physics2D.OverlapBoxAll(agent.transform.position, boxCollider2D.size, agent.transform.rotation.z);


			//cycles through all the colliders that the list created
			for (int i = 0; i < otherColliders.Length; i++)
			{
				//if the collider isnt one of its bullet and isnt his own collider than destroy
				if (otherColliders[i] != boxCollider2D && !otherColliders[i].CompareTag("Bullet") ) 
				{
                    Object.Destroy(agent.gameObject);
					//update score if they collide with each other or the player shot them. Will still destroy the object on impact
                    if ((otherColliders[i].CompareTag("Enemy") || otherColliders[i].CompareTag("PlayerBullet")))
                    {
                        GameManager.score++;
                        Object.Destroy(otherColliders[i].gameObject);
                    }
                }




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
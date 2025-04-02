using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DasherPatrolAT : ActionTask {




        //to get the location to go to
        public BBParameter<Transform> currentTarget;

        //Dasher regualar Speed
        public float speed;



        //To get the waypoints list from the spawner
        public BBParameter<List<Transform>> patrolPointsLocation;

        //To check for collision
        private BoxCollider2D boxCollider2D;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            //To get collder reference
            boxCollider2D = agent.GetComponent<BoxCollider2D>();
            //To set the first value to the first point on the list
            currentTarget.value = patrolPointsLocation.value[0];



            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {




		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            //To set the direction to move toward
            Vector3 directionToMove = currentTarget.value.position - agent.transform.position;

            //To move in the direction of the intended point at set speed
            agent.transform.position += directionToMove.normalized * speed * Time.deltaTime;
			
			
			//Debug to show the scan area (change the small values to the detection offset value on the detection script
			Debug.DrawLine(new Vector3(agent.transform.position.x, agent.transform.position.y + 0.6f), new Vector3(agent.transform.position.x - 30, agent.transform.position.y + 0.6f), Color.red);
            Debug.DrawLine(new Vector3(agent.transform.position.x, agent.transform.position.y - 0.6f), new Vector3(agent.transform.position.x - 30, agent.transform.position.y - 0.6f), Color.red);

            //Make a list of the collider 2d around it
            Collider2D[] otherColliders = Physics2D.OverlapBoxAll(agent.transform.position, boxCollider2D.size, agent.transform.rotation.z);

            //cycles through all the colliders that the list created
            for (int i = 0; i < otherColliders.Length; i++)
            {
                //if the collider isnt one of its bullet and isnt his own collider than destroy
                if (otherColliders[i] != boxCollider2D && !otherColliders[i].CompareTag("Bullet"))
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

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
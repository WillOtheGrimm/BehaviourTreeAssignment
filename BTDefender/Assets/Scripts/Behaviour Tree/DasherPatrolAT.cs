using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DasherPatrolAT : ActionTask {





        public BBParameter<Transform> currentTarget;
        public float speed;




        public BBParameter<List<Transform>> patrolPointsLocation;


        private BoxCollider2D boxCollider2D;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            boxCollider2D = agent.GetComponent<BoxCollider2D>();

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


            Vector3 directionToMove = currentTarget.value.position - agent.transform.position;
            agent.transform.position += directionToMove.normalized * speed * Time.deltaTime;
			
			
			
			Debug.DrawLine(new Vector3(agent.transform.position.x, agent.transform.position.y + 0.6f), new Vector3(agent.transform.position.x - 30, agent.transform.position.y + 0.6f), Color.red);
            Debug.DrawLine(new Vector3(agent.transform.position.x, agent.transform.position.y - 0.6f), new Vector3(agent.transform.position.x - 30, agent.transform.position.y - 0.6f), Color.red);


            Collider2D[] otherColliders = Physics2D.OverlapBoxAll(agent.transform.position, boxCollider2D.size, agent.transform.rotation.z);

            for (int i = 0; i < otherColliders.Length; i++)
            {
                if (otherColliders[i] != boxCollider2D && !otherColliders[i].CompareTag("Bullet"))
                {
                    Object.Destroy(agent.gameObject);
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
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DashAT : ActionTask {



        //To set dashing speed
		public float dashingSpeed;

        //To check for collision
        private BoxCollider2D boxCollider2D;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise

        protected override string OnInit() {

            //To get collder reference
            boxCollider2D = agent.GetComponent<BoxCollider2D>();

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

            //To make the dasher dash in a straight line at the set speed
			agent.transform.position += Vector3.left * dashingSpeed * Time.deltaTime;



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
                    if (otherColliders[i].CompareTag("Enemy") || otherColliders[i].CompareTag("PlayerBullet"))
                    {
                        GameManager.score++;
                        Object.Destroy(otherColliders[i].gameObject);
                    }
                    //will damage player on impact
					else if (otherColliders[i].CompareTag("Player"))
                    {
                        PlayerController player = otherColliders[i].GetComponent<PlayerController>();
						player.TakeDamage(1);
                    }

                }





            }






        }



        





        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}


		

        




    }
}
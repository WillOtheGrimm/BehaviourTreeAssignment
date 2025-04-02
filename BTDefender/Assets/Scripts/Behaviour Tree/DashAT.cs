using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DashAT : ActionTask {




		public float dashingSpeed;

		SpriteRenderer spriteRenderer;




        private BoxCollider2D boxCollider2D;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise

        protected override string OnInit() {
            boxCollider2D = agent.GetComponent<BoxCollider2D>();

            spriteRenderer = agent.GetComponent<SpriteRenderer>();
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


			agent.transform.position += Vector3.left * dashingSpeed * Time.deltaTime;
		



            Collider2D[] otherColliders = Physics2D.OverlapBoxAll(agent.transform.position, boxCollider2D.size, agent.transform.rotation.z);

            for (int i = 0; i < otherColliders.Length; i++)
            {
                if (otherColliders[i] != boxCollider2D && !otherColliders[i].CompareTag("Bullet"))
                {
                    Object.Destroy(agent.gameObject);
                    if (otherColliders[i].CompareTag("Enemy") || otherColliders[i].CompareTag("PlayerBullet"))
                    {
                        GameManager.score++;
                        Object.Destroy(otherColliders[i].gameObject);
                    }
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
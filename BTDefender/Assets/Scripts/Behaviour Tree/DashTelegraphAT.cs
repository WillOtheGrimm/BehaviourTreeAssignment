using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DashTelegraphAT : ActionTask {





		public Color baseColor;
		public Color allarmedColor;

		SpriteRenderer spriteRenderer;

		public float blinkTimer;
		//float elapsedTime;


		bool isTelegraphing = false;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			spriteRenderer = agent.GetComponent<SpriteRenderer>();


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//elapsedTime = blinkTimer;


			StartCoroutine(TeleGraph());


			//EndAction(true);
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



        IEnumerator ColorChange()

        {


            while (isTelegraphing)
            {

                spriteRenderer.color = allarmedColor;
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.color = baseColor;
                yield return new WaitForSeconds(0.1f);

            }


        }

        IEnumerator TeleGraph()
        {
			isTelegraphing = true;
            StartCoroutine(ColorChange());
            yield return new WaitForSeconds(blinkTimer);
			isTelegraphing = false;
            EndAction(true);



        }



    }
}
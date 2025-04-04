using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DashTelegraphAT : ActionTask {




		//Colors for the dash telegraph
		public Color baseColor;
		public Color allarmedColor;
		//Spriterender reference
		SpriteRenderer spriteRenderer;


		//How long its going to telegraph for
		public float blinkTimer;

		//to get out of while loop
		bool isTelegraphing = false;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			//to get the component 
			spriteRenderer = agent.GetComponent<SpriteRenderer>();


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {


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


		//Co routine to change between the 2 colors really fast (change the 0.1f to change color rate)
        IEnumerator ColorChange()

        {
		//if telegraphing trigger the color changes repeatively	

			if (spriteRenderer != null)
			{

            while (isTelegraphing)
            {

                spriteRenderer.color = allarmedColor;
                yield return new WaitForSeconds(0.1f);
                spriteRenderer.color = baseColor;
                yield return new WaitForSeconds(0.1f);

            }

			}

        }

        IEnumerator TeleGraph()
        {
			//When called set to true to trigger color change
			isTelegraphing = true;
            StartCoroutine(ColorChange());
			//make sure its blinks for the desired time
            yield return new WaitForSeconds(blinkTimer);
			//end blink and move on (dash)
			isTelegraphing = false;
            EndAction(true);



        }



    }
}
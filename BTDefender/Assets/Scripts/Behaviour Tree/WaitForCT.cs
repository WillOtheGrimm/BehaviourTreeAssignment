using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class WaitForCT : ConditionTask {

		//Set the timer to wait 
		public float timeToWait;
		float elapsedTime;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			//reset timer when called
            elapsedTime = timeToWait;

            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}


		 

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//if timer is the needed value, return true / move on
			elapsedTime -= Time.deltaTime;

			if (elapsedTime < 0)
			{
			elapsedTime = timeToWait;	
				return true;

			}
			else return false;
		}
	}
}
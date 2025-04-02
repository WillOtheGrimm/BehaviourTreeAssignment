using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectPlayerCT : ConditionTask {


        GameObject playerObject;
		public float detectionOffset;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
            playerObject = GameObject.FindGameObjectWithTag("Player");

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

			//if (playerObject != null) { }
			if (playerObject.transform.position.y <= agent.transform.position.y + detectionOffset  && playerObject.transform.position.y >= agent.transform.position.y - detectionOffset)
			{
				//Debug.Log("detected");
				return true;
			}

			else return false;

			
		}
	}
}
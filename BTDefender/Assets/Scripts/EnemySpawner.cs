using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //These were for the previous test (manual spawning) 
    public GameObject SniperAI;
    public GameObject DasherAI;

    //List of gameobject to spawn 
    public GameObject[] enemyList;



    //Values for random spawn timer
    float elapsedTime;
    float randomizedTime = 2;

    //To make sure the player is alive 
    public GameObject playerObject;



    //These 2 lists are to send the list of objects to the specific prefab its spawning 
    public List<Transform> sniperPatrolPoints = new List<Transform>();
    public List<Transform> dasherPatrolPoints = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        //make sure player is alive to spawn
        if (playerObject != null)
        {

            //Count timer down
            elapsedTime += Time.deltaTime;



            //When timer is at random timer value.
            if (elapsedTime >= randomizedTime)
            {
                //Random index set to spawn one of the two possible enemy
                int randomIndex = Random.Range(0, 2);

                //Spawn sniper if index is 0
                if (randomIndex == 0)
                {
                    //Return the blackboard of the instantiated object in order to then pass the value (list) in that prefab)
                    Blackboard sniperBlackboard = Instantiate(SniperAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
                    sniperBlackboard.SetVariableValue("patrolPointsList", sniperPatrolPoints);
                }
                //Spawn Dasher if index is 1
                else if (randomIndex == 1)
                {
                    //Return the blackboard of the instantiated object in order to then pass the value (list) in that prefab)
                    Blackboard dasherBlackboard = Instantiate(DasherAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
                    dasherBlackboard.SetVariableValue("dasherPointList", dasherPatrolPoints);
                }

                //reset timer
                elapsedTime = 0;
                //Change the random spawn timer
                randomizedTime = Random.Range(1, 4);

            }



        }


        //------------------------------------------------MANUAL SPAWNING SECTION

        /* if (Input.GetKeyDown(KeyCode.R))
         {

             Blackboard sniperBlackboard = Instantiate(SniperAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
             sniperBlackboard.SetVariableValue("patrolPointsList", sniperPatrolPoints);

             //Instantiate(SniperAI);


         }

         if (Input.GetKeyDown(KeyCode.T))
         {
             Blackboard dasherBlackboard = Instantiate(DasherAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
             dasherBlackboard.SetVariableValue("dasherPointList", dasherPatrolPoints);
         }*/


    }







}

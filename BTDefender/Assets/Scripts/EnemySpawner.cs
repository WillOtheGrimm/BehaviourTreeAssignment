using System.Collections;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    public GameObject SniperAI;
    public GameObject DasherAI;

    public GameObject[] enemyList;

    float elapsedTime;
    float randomizedTime = 2;

    // public Transform[] sniperPatrolPoints;
    public List<Transform> sniperPatrolPoints = new List<Transform>();
    public List<Transform> dasherPatrolPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {



        elapsedTime += Time.deltaTime;


        if (elapsedTime >= randomizedTime)
        {

          int randomIndex =   Random.Range(0, 2);
            

            if (randomIndex == 0 )
            {
                Blackboard sniperBlackboard = Instantiate(SniperAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
                sniperBlackboard.SetVariableValue("patrolPointsList", sniperPatrolPoints);
            }

            else if (randomIndex == 1 )
            {
                Blackboard dasherBlackboard = Instantiate(DasherAI, transform.position, Quaternion.identity).GetComponent<Blackboard>();
                dasherBlackboard.SetVariableValue("dasherPointList", dasherPatrolPoints);
            }

            elapsedTime = 0;
            randomizedTime = Random.Range(1, 6);

        }







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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{


    public Transform playerTransform;
    
    
    Vector3 playerPosition;
    Vector3 playerDirection;




    public float bulletSpeed;
    float step;


    // Start is called before the first frame update
    void Start()
    {
        step = bulletSpeed * Time.deltaTime;
        //playerPosition = playerTransform.position;


        playerDirection = playerPosition - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position =  Vector3.MoveTowards(transform.position, playerDirection , step);
        transform.position += bulletSpeed * Time.deltaTime * transform.right;

       // Debug.Log(playerPosition.ToString());
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerController playerScript = collision.GetComponent<PlayerController>();
        
        if (playerScript == null )
        {
            return;
        }
        playerScript.TakeDamage(1);

        Destroy(gameObject);

        Debug.Log("Health is: " + playerScript.playerHealth);



    }



}

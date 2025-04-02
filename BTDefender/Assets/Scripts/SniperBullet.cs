using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{

    //Player data
    public Transform playerTransform;
    Vector3 playerPosition;
    Vector3 playerDirection;



    //Bullet speed
    public float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        

        //Calculate the players direction
        playerDirection = playerPosition - transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(playerPosition.ToString());
        //transform.position =  Vector3.MoveTowards(transform.position, playerDirection , step);
        transform.position += bulletSpeed * Time.deltaTime * transform.right;

    }



    //checks if colliding with player in order to call the takeDamge function and remove hp from the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get reference to player script
        PlayerController playerScript = collision.GetComponent<PlayerController>();
        

        //if player is dead, move on
        if (playerScript == null )
        {
            return;
        }
        //call the take damage funciton 
        playerScript.TakeDamage(1);
        //Kill the bullet on impact
        Destroy(gameObject);
        //Display health when it hits
        Debug.Log("Health is: " + playerScript.playerHealth);



    }


    private void OnBecameInvisible()
    {
        //Destroy object when invisible
        Destroy(gameObject);
    }



}

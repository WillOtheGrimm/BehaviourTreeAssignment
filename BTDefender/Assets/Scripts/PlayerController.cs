using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Got the player movement code help from my roomate

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    //Player's health 
    public int playerHealth = 3;

    //Object to spawn bullet 
    public GameObject playerBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //Check for input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Make sure speed is consistent
        movement.Normalize();


        //Calls Shoot function when space is pressed
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }





    }

    //Update the rigidbody movement by the axis and speed 
    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    //Calculate the playe's health using the damage value (uses int in case i wanted some move to deal more damage
    public void TakeDamage(int damage)
    {
        //updates players health
        playerHealth -= damage;


        //If player health is 0 or below, Kill the object (to trigger other events)
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("dead");
        }


    }



    //When colliding with an enemy, take damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);

        }
    }



    //To spawn your bullets
    public void Shoot()
    {
        Instantiate(playerBullet, new Vector3(transform.position.x + 1, transform.position.y), Quaternion.identity);
    }





}
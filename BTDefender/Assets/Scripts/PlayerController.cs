using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Got the player movement code from my roomate



    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int playerHealth = 3;


    public GameObject playerBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        movement.x = Input.GetAxisRaw("Horizontal"); 
        movement.y = Input.GetAxisRaw("Vertical");  
        movement.Normalize();



        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }

        



    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }


    public void TakeDamage(int damage)
    {
    playerHealth -= damage; 



        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("dead");
        }


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1);

        }
    }




    public void Shoot()
    {
        Instantiate(playerBullet, new Vector3 (transform.position.x + 1 , transform.position.y), Quaternion.identity);
    }





}
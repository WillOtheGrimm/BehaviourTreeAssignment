using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TelegraphTest : MonoBehaviour
{



    //This is my testing script please dont pay attention to it.






    public Color color1;
    public Color color2;

    public float speed;
    bool isDashing = false;
    float xPos;


    public float chargeTimer;
    //float chargeTime = 0;

    SpriteRenderer spriteRenderer;

    float step;




    public GameObject bulletPrefab;
    public Transform playerTransform;


    public GameObject sniperAI;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;

        //  transform.position = new Vector2(xPos, transform.position.y);




        //chargeTime += Time.deltaTime;


        if (isDashing)
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine(Attack());


            /*chargeTime = 0;
            StartCoroutine(ColorChange());
           */
        }

        /*if (chargeTime > 3f)
        {
            StopCoroutine(ColorChange());
            isDashing = true;
        }*/





        // Debug.Log(chargeTime);






        //-------------------------for bullter testing----------------


        if (Input.GetKeyDown(KeyCode.Q))
        {
            Transform bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).transform;
            bullet.right = playerTransform.position - bullet.position;


        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(sniperAI, transform.position, Quaternion.identity);


        }






    }




    IEnumerator ColorChange()

    {


        while (!isDashing)
        {

            spriteRenderer.color = color1;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = color2;
            yield return new WaitForSeconds(0.1f);

        }


    }

    IEnumerator Attack()
    {

        StartCoroutine(ColorChange());
        yield return new WaitForSeconds(chargeTimer);

        isDashing = true;



    }





    void Dash()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 30, transform.position.y), step);
        //xPos += transform.position.x * speed * Time.deltaTime;


        // transform.position = new Vector2(transform.position.x * speed * Time.deltaTime, transform.position.y);
    }



}

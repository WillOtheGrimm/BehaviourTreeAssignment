using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBulllet : MonoBehaviour
{

    //Bullet speed 
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make bullet constantly move right
        transform.position += transform.right * speed * Time.deltaTime;
    }


    private void OnBecameInvisible()
    {
        //Destroy object when invisible
        Destroy(gameObject);
    }
}

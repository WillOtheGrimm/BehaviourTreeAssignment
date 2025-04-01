using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image[] hearts;
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }


    public void UpdateHealth ()
    {



        int playerHealth = 0;
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerController>().playerHealth;
        }


        
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = playerHealth > i;
        }

        

       





    }








}

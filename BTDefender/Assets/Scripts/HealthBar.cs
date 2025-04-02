using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    //To feed the image for the heart
    public Image[] hearts;
    //To get the reference of the player
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    //Method to update the healthbar relative to the players health value
    public void UpdateHealth ()
    {

        int playerHealth = 0;
        //Checks if player exist
        if (player != null)
        {
            //Gets reference to the player script and the player health value
            playerHealth = player.GetComponent<PlayerController>().playerHealth;
        }


        //Cycle through the list of heart and removes them when it loses hp
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = playerHealth > i;
        }

        

       





    }








}

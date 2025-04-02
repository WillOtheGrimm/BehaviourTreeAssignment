using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    //To get reference to the player
    public GameObject player;
    //Reference to the button
    public GameObject gameOverButton;

    //Reference for the Score text
    public GameObject scoreText;
    TextMeshProUGUI textMeshPro;

    //Static to change the score on other scripts
    public static int score = 0;




    // Start is called before the first frame update
    void Start()
    {
        // to restart the game time when the game is loaded (i set it to 0 later)
        Time.timeScale = 1;
        
        //Gets reference to component
        textMeshPro = scoreText.GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        //If player is dead, Show restart button and freeze game
        if (player == null)
        {
            gameOverButton.SetActive(true);
            Time.timeScale = 0;
        }


        //Update text with the score
        textMeshPro.text = "Score: " + score;


    }








    public void RestartGame ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

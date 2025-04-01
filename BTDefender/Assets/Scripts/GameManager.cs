using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{


    public GameObject player;
    public GameObject gameOverButton;

    public GameObject scoreText;
    TextMeshProUGUI textMeshPro;

    public static int score = 0;




    // Start is called before the first frame update
    void Start()
    {
    textMeshPro = scoreText.GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            gameOverButton.SetActive(true);
            Time.timeScale = 0;
        }



        textMeshPro.text = "Score: " + score;


    }








    public void RestartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

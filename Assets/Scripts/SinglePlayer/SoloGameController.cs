using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloGameController : MonoBehaviour
{
    public static SoloGameController instance;
    public int touches = 7;
    public bool isGameOver = false;
    public GameObject levelCompleteText;
    public GameObject gameOverText;
    public bool isComplete = false;

    void Awake() 
    {   //creating Solo Game Controller instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
   
    void Update() 
    {   //win-lose conditions
        
        if (touches == 0 && isComplete != true)
        {
            isGameOver = true;
        }
        else if (touches < 0)
        {
            touches = 0;
        }
        if (isGameOver)
        {
            gameOverText.SetActive(true);
        }
      
    }
    public void PlayerScored()
    {  //player score method
        if (isGameOver != true)
        {
            isComplete = true;
            levelCompleteText.SetActive(true);
        }
        else
        {
            isComplete = false;
        }
        
    }
}

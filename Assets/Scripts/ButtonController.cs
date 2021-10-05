using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public AudioSource buttonClick;
    public AudioSource buttonHover;
    private Scene currentScene;
    void Start() 
    {
        //buttonClick = GetComponent<AudioSource>();
        //buttonHover = GetComponent<AudioSource>();
        currentScene = SceneManager.GetActiveScene();
    }
    //main menu button actions
    public void PvpButtonClicked()
    {
        buttonClick.Play();
        SceneManager.LoadScene(1);
    }
    public void SinglePlayerButtonClicked()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Level 0");
    }
    public void ButtonHover()
    {
        buttonHover.Play();
    }

    public void Exitgame()
    {
        buttonClick.Play();
        Application.Quit();
    }
    //single player mode buttons actions
    public void NextLevel()
    {
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void RestartLevel()
    {   
        buttonClick.Play();
        SceneManager.LoadScene(currentScene.name);
    }
    public void ExitToMainMenu()
    {
        buttonClick.Play();
        SceneManager.LoadScene(0);
    }
}

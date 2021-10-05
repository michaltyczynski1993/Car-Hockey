using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public GameObject touchCount;
    public GameObject nextButton;
    public GameObject exitButton;
    public GameObject restartButton;
    public GameObject levelText;

    void Start()
    {
      levelText.GetComponent<Text>().text =  SceneManager.GetActiveScene().name;
    }
    void Update()
    {
      touchCount.GetComponent<Text>().text = "Touches: " + SoloGameController.instance.touches;
      if (SoloGameController.instance.isComplete == true)
      {
        nextButton.SetActive(true);
        exitButton.SetActive(true);
        restartButton.SetActive(true);
      }
      if (SoloGameController.instance.isGameOver == true)
      {
        exitButton.SetActive(true);
        restartButton.SetActive(true);
      }
    }
}

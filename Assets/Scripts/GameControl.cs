using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{   //Variables
    public static GameControl instance;
    private int p1Score = 0;
    private int p2Score = 0;
    //object access
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    private Vector2 player1Pos; //position on start
    private Vector2 player2Pos;
    private Vector2 ballPos;
    private Rigidbody2D ballRb;
    public Text player1Score;
    public Text player2Score;
    public GameObject GameOverText;
    public Text gameOverText;
    public bool isGameOver = false;

    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ballPos = new Vector2(ball.transform.position.x, ball.transform.position.y);
        ballRb = ball.GetComponent<Rigidbody2D>();
        player1Pos = new Vector2(player1.transform.position.x, player1.transform.position.y);
        player2Pos = new Vector2(player2.transform.position.x, player2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (p1Score == 5 || p2Score == 5)
        {
            isGameOver = true;
            if(p1Score == 5)
            {
                gameOverText.text = "Player 1 won!";
            }
            if(p2Score == 5)
            {
                gameOverText.text = "Player 2 won!";
            }
            GameOverText.SetActive(true);
            if (Input.GetButtonDown("MouseLeftButton"))
            {
                SceneManager.LoadScene("PvPMode");
            }
            if (Input.GetButtonDown("Exit"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void P1Scored()
    {
        p1Score ++;
        Debug.Log(p1Score);
        player1Score.text = p1Score.ToString();
        player1.transform.position = player1Pos;
        player2.transform.position = player2Pos;
        player1.transform.rotation= Quaternion.Euler(0,0,0);
        player2.transform.rotation= Quaternion.Euler(0,0,0);
        ball.transform.position = ballPos;
        ballRb.velocity = new Vector2(0 , 0);
    }
    public void P2Scored()
    {
        p2Score++;
        Debug.Log(p2Score);
        player2Score.text = p2Score.ToString();
        player1.transform.position = player1Pos;
        player2.transform.position = player2Pos;
        player1.transform.rotation= Quaternion.Euler(0,0,0);
        player2.transform.rotation= Quaternion.Euler(0,0,0);
        ball.transform.position = ballPos;
        ballRb.velocity = new Vector2(0 , 0);
        
    }
}

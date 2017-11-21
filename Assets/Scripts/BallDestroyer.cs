using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDestroyer : MonoBehaviour 
{
    public GameObject livesLeftLabelRef, gameOverLabelRef, highScoreRef;
    public int livesLeft;

    void Start()
    {
        livesLeft = 10;
        setLivesLeftLabel();
    }

    void Update()
    {
        if (gameIsOver())
            pauseGame();
        
        if (playerWantsToPlayAgain())
            resetGame();
    }

    bool gameIsOver()
    {
        return ((Time.timeScale == 1) && (livesLeft <= 0));
    }

    void pauseGame()
    {
        gameOverLabelRef.SetActive (true);
        Time.timeScale = 0;
    }

    bool playerWantsToPlayAgain()
    {
        return ((Time.timeScale == 0) && (Input.GetKeyUp (KeyCode.Space)));
    }

    void resetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene ("Game");
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            livesLeft--;
            setLivesLeftLabel();
            Destroy (collision.gameObject);
        }
    }

    public void setLivesLeftLabel()
    {
        livesLeftLabelRef.GetComponent<TextMesh>().text = "Lives: " + livesLeft.ToString();
    }
}
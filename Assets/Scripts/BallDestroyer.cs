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
        if (livesLeft <= 0)
        {
            highScoreRef.SetActive (true);
            highScoreRef.GetComponent<HighScore>().setHighScoreLabel();
            Time.timeScale = 0;
            gameOverLabelRef.SetActive (true);
        }

        // Reset game
        if (Time.timeScale == 0 && Input.GetKeyUp (KeyCode.Space))
        {
            SceneManager.LoadScene ("Game");
            Time.timeScale = 1;
        }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallDestroyer : MonoBehaviour 
{
    public GameObject livesLeftLabelRef, gameOverLabelRef, highScoreRef;
    public int livesLeft;
    bool gameIsPaused;

    void Start()
    {
        livesLeft = 10;
        gameIsPaused = false;
        setLivesLeftLabel();
    }

    void Update()
    {
        if ((livesLeft <= 0) && (! gameIsPaused))
        {
            gameOverLabelRef.SetActive (true);
            gameIsPaused = true;
            Time.timeScale = 0;
        }

        // Reset game
        if (Time.timeScale == 0 && Input.GetKeyUp (KeyCode.Space))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene ("Game");
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
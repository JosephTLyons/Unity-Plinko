using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour 
{
    static int gameScore;
    public KeyCode moveLeft, moveRight;
    public float speedX;

    void Start()
    {
        gameScore = 0;
        speedX    = 0;
    }

	void Update() 
    {
        // Left and right movement of paddle
        if (Input.GetKey (moveLeft)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speedX, 0f);
        } 

        else if (Input.GetKey (moveRight)) 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, 0f);
        }

        else 
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
            setScoreLabel (collision.gameObject.GetComponent<BallControl>().ballValue);
        }
    }

    void setScoreLabel(int newValue)
    {
        gameScore += newValue;
        GetComponentInChildren<TextMesh>().text = gameScore.ToString();
    }
}
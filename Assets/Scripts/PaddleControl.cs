﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour 
{
    static int gameScore;
    public KeyCode moveLeft, moveRight;
    public float speedX;
    int ballsCaptured;

    public GameObject BallDestroyerRef;

    void Start()
    {
        gameScore = 0;
        ballsCaptured = 0;
    }

	void Update() 
    {
        if (Input.GetKey (moveLeft))
            movePaddleHorizontally (-speedX);
        
        else if (Input.GetKey (moveRight))
            movePaddleHorizontally (speedX);
        
        else
            movePaddleHorizontally (0);
	}

    void movePaddleHorizontally(float valueToMoveHorizontally)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2 (valueToMoveHorizontally, 0f);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play();
            setScoreLabel (collision.gameObject.GetComponent<BallControl>().ballWorth);
            Destroy (collision.gameObject);

            if (++ballsCaptured == 10)
            {
                ballsCaptured = 0;
                BallDestroyerRef.GetComponent<BallDestroyer>().livesLeft++;
                BallDestroyerRef.GetComponent<BallDestroyer>().setLivesLeftLabel();
            }
        }
    }

    void setScoreLabel(int newValue)
    {
        gameScore += newValue;
        GetComponentInChildren<TextMesh>().text = gameScore.ToString();
    }
}
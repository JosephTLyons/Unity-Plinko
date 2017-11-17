﻿using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    int ballsToDispense;
    int ballDropDelayTimeTemp;
    const int BALL_DROP_DELAY_TIME = 40;
    int level;
    int levelPauseTime;

    static GameObject ball;
    public GameObject ballRef;

	void Start () 
	{
        level = 1;
        setLevelLabel();
        levelPauseTime = 0;

        ballsToDispense = 1;
        ballDropDelayTimeTemp = BALL_DROP_DELAY_TIME;
	}

	void Update()
    {
        if (levelPauseTime-- <= 0)
        {
            if (ballDropDelayTimeTemp-- <= 0)
            {
                if ((ballsToDispense--) > 0)
                {
                    setLevelLabel();
                    dropBall();
                }

                ballDropDelayTimeTemp = BALL_DROP_DELAY_TIME;
            } 

            if (levelIsOver())
            {
                changeLevel();
            }
        }
    }

    void changeLevel()
    {
        ballsToDispense = ++level;
        levelPauseTime = 250;
    }

    bool levelIsOver()
    {
        return (ballsToDispense <= 0);
    }

    void dropBall()
    {
        ball = Instantiate (ballRef) as GameObject;
        float ballXPosition = Random.Range (-570, 570) / 100.0f;
        ball.transform.position = new Vector3 (ballXPosition, 5.5f, 0);
    }

    void setLevelLabel()
    {
        GetComponentInChildren<TextMesh>().text = "Level: " + level.ToString();
    }
}
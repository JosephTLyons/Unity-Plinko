using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    int ballsToDispense;
    int ballDropDelayTimeTemp;
    const int BALL_DROP_DELAY_TIME = 40;
    int level;
    int levelSwitchPauseTime;

    static GameObject ball;
    public GameObject ballRef;

	void Start () 
	{
        level = 1;
        setLevelLabel();
        levelSwitchPauseTime = 0;

        ballsToDispense = 1;
        ballDropDelayTimeTemp = BALL_DROP_DELAY_TIME;
	}

	void Update()
    {
        if (levelSwitchPauseTime-- <= 0)
        {
            if (ballDropDelayTimeTemp-- <= 0)
            {
                if (! levelIsOver())
                    continueGamePlay();

                ballDropDelayTimeTemp = BALL_DROP_DELAY_TIME;
            } 

            if (levelIsOver())
                changeLevel();
        }
    }

    bool levelIsOver()
    {
        return (ballsToDispense <= 0);
    }

    void continueGamePlay()
    {
        dropBall();
        ballsToDispense--;
        setLevelLabel();
    }

    void changeLevel()
    {
        ballsToDispense = ++level;
        levelSwitchPauseTime = 250;
    }

    void dropBall()
    {
        ball = Instantiate (ballRef) as GameObject;

        placeBallOnRandomXCoordinate();
        giveBallRandomHorizontalVelocity();
    }

    void placeBallOnRandomXCoordinate()
    {
        float ballXPosition = Random.Range (-Screen.width, Screen.width) / 100.0f;
        ball.transform.position = new Vector3 (ballXPosition, 5.5f, 0);
    }

    // Without this function, there's a chance a ball can fall directly downwards and land balanced on a peg
    void giveBallRandomHorizontalVelocity()
    {
        float ballVelocityOnXAxis = Random.Range (-4, 4);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector3 (ballVelocityOnXAxis, 0, 0);
    }

    public void setLevelLabel()
    {
        GetComponentInChildren<TextMesh>().text = "Level: " + level.ToString();
    }
        
}
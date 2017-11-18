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
    public GameObject paddleRef;
    public GameObject plusOneInXLabelRef;

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
        if (! gameIsOver ())
        {
            // This is used to briefly pause the dropping of balls between levels
            if (levelSwitchPauseTime-- <= 0)
            {
                // This is used to stagger the dropping of balls, so they don't all drop at once
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

        setPlusOneInXLabel();
    }

    bool gameIsOver()
    {
        return (Time.timeScale == 0);
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

        placeBallAtRandomXCoordinate();
        giveBallRandomHorizontalVelocity();
    }

    void placeBallAtRandomXCoordinate()
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

    void setPlusOneInXLabel()
    {
        int captured = paddleRef.GetComponent<PaddleControl>().ballsCaptured;
        plusOneInXLabelRef.GetComponent<TextMesh>().text = "+1 in: " + (10 - captured).ToString ();
    }
}
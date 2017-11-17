using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    int ballsToDispense;
    int ballDropDelayTime;
    int time;
    int level;
    int levelPauseTime;

    static GameObject ball;
    public GameObject ballRef;

	void Start () 
	{
        levelPauseTime = 0;
        ballsToDispense = 1;
        time = 40;
        level = 1;
        ballDropDelayTime = time;
        setLevelLabel();
	}

	void Update()
    {
        if (levelPauseTime-- <= 0)
        {
            if (ballDropDelayTime-- <= 0)
            {
                if ((ballsToDispense--) > 0)
                {
                    setLevelLabel();
                    dropBall();
                }

                ballDropDelayTime = time;
            }

            // Commence delay between levels, let user relax for a few seconds
            if (levelIsOver())
            {
                ballsToDispense = ++level;
                levelPauseTime = 250;
            }
        }
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
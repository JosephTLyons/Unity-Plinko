using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    int ballCount;
    int ballDropDelayTime;
    int time;
    int level;
    int levelPauseTime;

    static GameObject ball;
    public GameObject ballRef;

	void Start () 
	{
        levelPauseTime = 0;
        ballCount = 1;
        time = 40;
        level = 1;
        ballDropDelayTime = time;
	}

	void Update()
    {
        if (levelPauseTime-- <= 0)
        {
            if (ballDropDelayTime-- <= 0)
            {
                if ((ballCount--) > 0)
                    dropBall();

                ballDropDelayTime = time;
            }

            if (ballCount <= 0)
            {
                ballCount = ++level;
                levelPauseTime = 250;
            }
        }
    }

    void dropBall()
    {
        ball = Instantiate (ballRef) as GameObject;
        float ballXPosition = Random.Range (-570, 570) / 100.0f;
        ball.transform.position = new Vector3 (ballXPosition, 5.5f, 0);
    }
}

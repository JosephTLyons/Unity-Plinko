using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
	static int gameScore = 0;
    int ballCount;
    int ballDropDelayTime;

    static GameObject ball;
    public GameObject ballRef;

	void Start () 
	{
        ballCount = 3;
        ballDropDelayTime = 40;
	}

	void Update()
    {
        if (ballDropDelayTime-- <= 0)
        {
            if ((ballCount--) > 0)
            {
                dropBall();
            }

            ballDropDelayTime = 40;
        }
    }

    void dropBall()
    {
        ball = Instantiate (ballRef) as GameObject;
        float ballXPosition = Random.Range (-570, 570) / 100.0f;
        ball.transform.position = new Vector3 (ballXPosition, 6, 0);
    }
}

using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
	static int gameScore = 0;

    static GameObject ball;
    public GameObject ballRef;

	// Use this for initialization
	void Start () 
	{
        dropBall();
	}

    void dropBall()
    {
        ball = Instantiate (ballRef) as GameObject;
        float ballXPosition = Random.Range (-570, 570) / 100.0f;
        ball.transform.position = new Vector3 (ballXPosition, 5, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
    }
}
